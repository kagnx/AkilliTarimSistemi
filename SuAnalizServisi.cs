using AkilliTarimSistemi.Core.DTOs;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.Core.Enums;
using AkilliTarimSistemi.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services
    {
        public class SuAnalizServisi : ISuAnalizServisi
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILogger<SuAnalizServisi> _logger;

            public SuAnalizServisi(IUnitOfWork unitOfWork, ILogger<SuAnalizServisi> logger)
            {
                _unitOfWork = unitOfWork;
                _logger = logger;
            }

            public async Task<IEnumerable<SuAnalizDto>> GetAllAsync()
            {
                try
                {
                    var list = await _unitOfWork.GetAllIncludingAsync<SuAnaliz>(x => x.Tarla);

                    // null ise boş liste döner, syntax hatası giderildi
                    return (list ?? Enumerable.Empty<SuAnaliz>())
                               .OrderByDescending(x => x.AnalizTarihi)
                               .Select(MapToDto)
                               .ToList()!;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Tüm su analizleri getirilirken hata oluştu");
                    throw;
                }
            }

            public async Task<SuAnalizDto?> GetByIdAsync(int id)
            {
                try
                {
                    var analiz = await _unitOfWork.GetSingleIncludingAsync<SuAnaliz>(
                        x => x.Id == id,
                        x => x.Tarla);

                    return analiz != null ? MapToDto(analiz) : null!;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Su analizi getirilirken hata oluştu. ID: {id}");
                    throw;
                }
            }

            public async Task<SuAnalizDto?> GetByTarlaIdAsync(int tarlaId)
            {
                try
                {
                    var analizler = await _unitOfWork.GetIncludingAsync<SuAnaliz>(
                        x => x.TarlaId == tarlaId,
                        x => x.Tarla);

                    // null kontrolü eklendi
                    var sonAnaliz = analizler?.OrderByDescending(x => x.AnalizTarihi).FirstOrDefault();

                    return sonAnaliz != null ? MapToDto(sonAnaliz) : null!;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Tarlaya ait su analizi getirilirken hata oluştu. TarlaId: {tarlaId}");
                    throw;
                }
            }

            public async Task<IEnumerable<SuAnalizDto>> GetByTarihAraligiAsync(DateTime baslangic, DateTime bitis)
            {
                try
                {
                    var list = await _unitOfWork.GetIncludingAsync<SuAnaliz>(
                        x => x.AnalizTarihi >= baslangic && x.AnalizTarihi <= bitis,
                        x => x.Tarla);

                    return (list ?? Enumerable.Empty<SuAnaliz>())
                               .OrderByDescending(x => x.AnalizTarihi)
                               .Select(MapToDto)
                               .ToList()!;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Tarih aralığına göre su analizleri getirilirken hata oluştu");
                    throw;
                }
            }

            public async Task<SuAnalizDto> AddAsync(SuAnalizDto dto)
            {
                try
                {
                    var entity = MapToEntity(dto);
                    entity.AnalizTarihi = DateTime.Now;
                    entity.KayitTarihi = DateTime.Now;
                    entity.AktifMi = true;

                    entity.SuKalitesiSkoru = SuKalitesiSkoruHesapla(entity);
                    entity.SulamayaUygun = entity.SuKalitesiSkoru >= 60;
                    entity.OneriMetni = SulamaOnerisiOlustur(entity);

                    await _unitOfWork.SuAnalizleri.AddAsync(entity);
                    await _unitOfWork.SaveChangesAsync();

                    _logger.LogInformation($"Yeni su analizi eklendi. ID: {entity.Id}, TarlaId: {entity.TarlaId}");
                    return MapToDto(entity);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Su analizi eklenirken hata oluştu");
                    throw;
                }
            }

            public async Task<SuAnalizDto> UpdateAsync(SuAnalizDto dto)
            {
                try
                {
                    var entity = await _unitOfWork.SuAnalizleri.GetByIdAsync(dto.Id);
                    if (entity == null)
                        throw new Exception($"Su analizi bulunamadı. ID: {dto.Id}");

                    // Güncellemeler...
                    entity.AnalizTarihi = dto.AnalizTarihi;
                    entity.TarlaId = dto.TarlaId;
                    entity.UrunTipi = dto.UrunTipi.ToString();
                    entity.Kaynak = dto.SuKaynagi;
                    entity.pH = dto.pH;
                    entity.EC = dto.ElektrikselIletkenlik_EC;
                    entity.Klor = dto.Klorur_Cl;
                    entity.Nitrat = dto.Nitrat_NO3;
                    entity.Nitrit = dto.Nitrit_NO2;
                    entity.Sodyum = dto.Sodyum_Na;
                    entity.Sicaklik = dto.Sicaklik;
                    entity.Bulaniklik = dto.Bulaniklik;
                    entity.Sulfat = dto.Sülfat_SO4;
                    entity.Bikarbonat = dto.Bikarbonat_HCO3;
                    entity.Karbonat = dto.Karbonat_CO3;
                    entity.Kalsiyum = dto.Kalsiyum_Ca;
                    entity.Magnezyum = dto.Magnezyum_Mg;
                    entity.Potasyum = dto.Potasyum_K;
                    entity.Arsenik = dto.Arsenik_As;
                    entity.Kadmiyum = dto.Kadmiyum_Cd;
                    entity.Kursun = dto.Kursun_Pb;
                    entity.Civa = dto.Civa_Hg;
                    entity.Krom = dto.Krom_Cr;
                    entity.Nikel = dto.Nikel_Ni;
                    entity.SAR = dto.SAR_SodyumAdsorpsiyonOrani;
                    entity.RSC = dto.RSC_ArtikSodyumKarbonat;
                    entity.SSP = dto.SSP_SodyumYuzdesi;
                    entity.TuzlulukSinifi = dto.TuzlulukSinifi;
                    entity.AlkaliniteSinifi = dto.AlkaliniteSinifi;
                    entity.KoliformBakteri = dto.KoliformBakteri;
                    entity.EscherichiaColi = dto.EschericiaColi;
                    entity.OnerilenTedavi = dto.OnerilenTedavi;
                    entity.AnaliziYapanKullaniciId = dto.AnaliziYapanKullaniciId;

                    entity.SuKalitesiSkoru = SuKalitesiSkoruHesapla(entity);
                    entity.SulamayaUygun = entity.SuKalitesiSkoru >= 60;
                    entity.OneriMetni = SulamaOnerisiOlustur(entity);

                    _unitOfWork.SuAnalizleri.Update(entity);
                    await _unitOfWork.SaveChangesAsync();

                    _logger.LogInformation($"Su analizi güncellendi. ID: {entity.Id}");
                    return MapToDto(entity);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Su analizi güncellenirken hata oluştu. ID: {dto.Id}");
                    throw;
                }
            }

            public async Task DeleteAsync(int id)
            {
                try
                {
                    var entity = await _unitOfWork.SuAnalizleri.GetByIdAsync(id);
                    if (entity != null)
                    {
                        _unitOfWork.SuAnalizleri.Delete(entity);
                        await _unitOfWork.SaveChangesAsync();
                        _logger.LogInformation($"Su analizi silindi. ID: {id}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Su analizi silinirken hata oluştu. ID: {id}");
                    throw;
                }
            }

            public async Task<bool> SuKalitesiniDegerlendirAsync(int id)
            {
                try
                {
                    var analiz = await _unitOfWork.SuAnalizleri.GetByIdAsync(id);
                    if (analiz == null)
                        throw new Exception($"Su analizi bulunamadı. ID: {id}");

                    analiz.SuKalitesiSkoru = SuKalitesiSkoruHesapla(analiz);
                    analiz.SulamayaUygun = analiz.SuKalitesiSkoru >= 60;
                    analiz.OneriMetni = SulamaOnerisiOlustur(analiz);

                    _unitOfWork.SuAnalizleri.Update(analiz);
                    await _unitOfWork.SaveChangesAsync();

                    return analiz.SulamayaUygun;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Su kalitesi değerlendirilirken hata oluştu. ID: {id}");
                    throw;
                }
            }

            public async Task<IEnumerable<SuAnalizDto>> GetUygunOlmayanAnalizlerAsync()
            {
                try
                {
                    var list = await _unitOfWork.GetIncludingAsync<SuAnaliz>(
                        x => x.SulamayaUygun == false || x.SuKalitesiSkoru < 60,
                        x => x.Tarla);

                    return (list ?? Enumerable.Empty<SuAnaliz>())
                               .OrderBy(x => x.SuKalitesiSkoru)
                               .Select(MapToDto)
                               .ToList()!;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Uygun olmayan su analizleri getirilirken hata oluştu");
                    throw;
                }
            }

            public async Task<SuIstatistikDto> GetIstatistiklerAsync()
            {
                try
                {
                    var analizler = await _unitOfWork.SuAnalizleri.GetAllAsync();

                    if (analizler == null || !analizler.Any())
                        return new SuIstatistikDto();

                    return new SuIstatistikDto
                    {
                        ToplamAnalizSayisi = analizler.Count(),
                        OrtalamaSuKalitesi = analizler.Average(x => x.SuKalitesiSkoru),
                        UygunAnalizSayisi = analizler.Count(x => x.SulamayaUygun),
                        UygunOlmayanAnalizSayisi = analizler.Count(x => !x.SulamayaUygun),
                        OrtalamaPH = analizler.Average(x => x.pH),
                        OrtalamaEC = analizler.Average(x => x.EC),
                        OrtalamaNitrat = analizler.Average(x => x.Nitrat),
                        SonAnalizTarihi = analizler.Max(x => x.AnalizTarihi),
                        EnYuksekSkor = analizler.Max(x => x.SuKalitesiSkoru),
                        EnDusukSkor = analizler.Min(x => x.SuKalitesiSkoru)
                    };
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Su analizi istatistikleri getirilirken hata oluştu");
                    throw;
                }
            }

            // ==================== YARDIMCI METODLAR ====================
            private SuAnalizDto MapToDto(SuAnaliz entity)
            {
                // UrunTipi enum ise string'den parse et
                var urunTipi = UrunTipi.Bugday;
                if (!string.IsNullOrEmpty(entity.UrunTipi))
                {
                    Enum.TryParse<UrunTipi>(entity.UrunTipi, true, out var parsedTipi);
                    urunTipi = parsedTipi;
                }

                return new SuAnalizDto
                {
                    Id = entity.Id,
                    TarlaId = entity.TarlaId,
                    TarlaAdi = entity.Tarla?.TarlaAdi ?? string.Empty,
                    AnalizTarihi = entity.AnalizTarihi,
                    UrunTipi = urunTipi,
                    SuKaynagi = entity.Kaynak ?? string.Empty,
                    pH = entity.pH,
                    ElektrikselIletkenlik_EC = entity.EC,
                    Sicaklik = entity.Sicaklik,
                    Bulaniklik = entity.Bulaniklik,
                    Klorur_Cl = entity.Klor,
                    Sülfat_SO4 = entity.Sulfat,
                    Bikarbonat_HCO3 = entity.Bikarbonat,
                    Karbonat_CO3 = entity.Karbonat,
                    Nitrat_NO3 = entity.Nitrat,
                    Nitrit_NO2 = entity.Nitrit,
                    Kalsiyum_Ca = entity.Kalsiyum,
                    Magnezyum_Mg = entity.Magnezyum,
                    Sodyum_Na = entity.Sodyum,
                    Potasyum_K = entity.Potasyum,
                    Arsenik_As = entity.Arsenik,
                    Kadmiyum_Cd = entity.Kadmiyum,
                    Kursun_Pb = entity.Kursun,
                    Civa_Hg = entity.Civa,
                    Krom_Cr = entity.Krom,
                    Nikel_Ni = entity.Nikel,
                    SAR_SodyumAdsorpsiyonOrani = entity.SAR,
                    RSC_ArtikSodyumKarbonat = entity.RSC,
                    SSP_SodyumYuzdesi = entity.SSP,
                    TuzlulukSinifi = entity.TuzlulukSinifi ?? string.Empty,
                    AlkaliniteSinifi = entity.AlkaliniteSinifi ?? string.Empty,
                    KoliformBakteri = entity.KoliformBakteri,
                    EschericiaColi = entity.EscherichiaColi,
                    SulamaIcinUygunMu = entity.SulamayaUygun,
                    UygunlukAciklamasi = entity.OneriMetni ?? string.Empty,
                    OnerilenTedavi = entity.OnerilenTedavi ?? string.Empty,
                    AnaliziYapanKullaniciId = entity.AnaliziYapanKullaniciId ?? 0,
                    KayitTarihi = entity.KayitTarihi,
                    AktifMi = entity.AktifMi
                };
            }

            private SuAnaliz MapToEntity(SuAnalizDto dto)
            {
                return new SuAnaliz
                {
                    Id = dto.Id,
                    AnalizTarihi = dto.AnalizTarihi,
                    TarlaId = dto.TarlaId,
                    UrunTipi = dto.UrunTipi.ToString(),
                    Kaynak = dto.SuKaynagi,
                    pH = dto.pH,
                    EC = dto.ElektrikselIletkenlik_EC,
                    Sicaklik = dto.Sicaklik,
                    Bulaniklik = dto.Bulaniklik,
                    Klor = dto.Klorur_Cl,
                    Sulfat = dto.Sülfat_SO4,
                    Bikarbonat = dto.Bikarbonat_HCO3,
                    Karbonat = dto.Karbonat_CO3,
                    Nitrat = dto.Nitrat_NO3,
                    Nitrit = dto.Nitrit_NO2,
                    Kalsiyum = dto.Kalsiyum_Ca,
                    Magnezyum = dto.Magnezyum_Mg,
                    Sodyum = dto.Sodyum_Na,
                    Potasyum = dto.Potasyum_K,
                    Arsenik = dto.Arsenik_As,
                    Kadmiyum = dto.Kadmiyum_Cd,
                    Kursun = dto.Kursun_Pb,
                    Civa = dto.Civa_Hg,
                    Krom = dto.Krom_Cr,
                    Nikel = dto.Nikel_Ni,
                    SAR = dto.SAR_SodyumAdsorpsiyonOrani,
                    RSC = dto.RSC_ArtikSodyumKarbonat,
                    SSP = dto.SSP_SodyumYuzdesi,
                    TuzlulukSinifi = dto.TuzlulukSinifi,
                    AlkaliniteSinifi = dto.AlkaliniteSinifi,
                    KoliformBakteri = dto.KoliformBakteri,
                    EscherichiaColi = dto.EschericiaColi,
                    SulamayaUygun = dto.SulamaIcinUygunMu,
                    OneriMetni = dto.UygunlukAciklamasi,
                    OnerilenTedavi = dto.OnerilenTedavi,
                    AnaliziYapanKullaniciId = dto.AnaliziYapanKullaniciId,
                    KayitTarihi = dto.KayitTarihi,
                    AktifMi = dto.AktifMi
                };
            }

            private int SuKalitesiSkoruHesapla(SuAnaliz analiz)
            {
                int skor = 100;

                // pH - once ciddi sapmalari kontrol et
                if (analiz.pH < 6.0 || analiz.pH > 8.0) skor -= 30;
                else if (analiz.pH < 6.5 || analiz.pH > 7.5) skor -= 15;

                if (analiz.EC > 3.0) skor -= 25;
                else if (analiz.EC > 2.0) skor -= 15;
                else if (analiz.EC > 1.5) skor -= 8;

                if (analiz.Nitrat > 50) skor -= 20;
                else if (analiz.Nitrat > 25) skor -= 10;

                if (analiz.Nitrit > 0.1) skor -= 15;
                else if (analiz.Nitrit > 0.03) skor -= 8;

                if (analiz.Sodyum > 100) skor -= 15;
                else if (analiz.Sodyum > 50) skor -= 8;

                if (analiz.Klor > 200) skor -= 15;
                else if (analiz.Klor > 100) skor -= 8;

                return Math.Max(0, Math.Min(100, skor));
            }

            private string SulamaOnerisiOlustur(SuAnaliz analiz)
            {
                var oneri = new System.Text.StringBuilder();

                if (!analiz.SulamayaUygun)
                {
                    oneri.AppendLine("⚠️ UYARI: Bu su kaynağı doğrudan sulama için UYGUN DEĞİLDİR!");
                    oneri.AppendLine();
                }

                if (analiz.pH < 6.0 || analiz.pH > 8.0)
                    oneri.AppendLine($"• pH değeri ({analiz.pH:F1}) uygun değil. pH düzenleyici kimyasallar kullanılmalı.");

                if (analiz.EC > 2.0)
                    oneri.AppendLine($"• EC değeri ({analiz.EC:F2}) yüksek. Su seyreltilmeli veya tuzluluğa dayanıklı ürünler tercih edilmeli.");

                if (analiz.Nitrat > 25)
                    oneri.AppendLine($"• Nitrat seviyesi ({analiz.Nitrat:F1}) yüksek. Gübreleme programı gözden geçirilmeli.");

                if (analiz.Sodyum > 50)
                    oneri.AppendLine($"• Sodyum seviyesi ({analiz.Sodyum:F1}) yüksek. Toprak sodyumu izlenmeli.");

                if (oneri.Length == 0)
                {
                    oneri.AppendLine("✅ Su kalitesi İYİ. Güvenle sulama yapılabilir.");
                    oneri.AppendLine("📌 Öneri: Rutin analizlere devam edin (3 ayda bir).");
                }
                else
                {
                    oneri.Insert(0, "🔧 ÖNERİLER:\n");
                    oneri.AppendLine("\n📌 Uyarı: Bu öneriler doğrultusunda hareket edilmezse ürün kaybı yaşanabilir.");
                }

                return oneri.ToString();
            }
        }
    }