using AkilliTarimSistemi.Core.DTOs;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services
{
    public class SuKaynagiServisi : ISuKaynagiServisi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SuKaynagiServisi> _logger;

        public SuKaynagiServisi(IUnitOfWork unitOfWork, ILogger<SuKaynagiServisi> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<SuKaynagi> GetSuKaynagiByIdAsync(int id)
        {
            try
            {
                var suKaynagi = await _unitOfWork.SuKaynaklari.GetByIdAsync(id);
                if (suKaynagi == null)
                    throw new Exception($"Su kaynağı bulunamadı. ID: {id}");

                return suKaynagi;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Su kaynağı getirilirken hata oluştu. ID: {id}");
                throw;
            }
        }

        public async Task<List<SuKaynagi>> GetAllSuKaynaklariAsync()
        {
            try
            {
                var suKaynaklari = await _unitOfWork.SuKaynaklari.GetAllAsync();
                return suKaynaklari.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Tüm su kaynakları getirilirken hata oluştu");
                throw;
            }
        }

        public async Task<List<SuKaynagi>> GetAktifSuKaynaklariAsync()
        {
            try
            {
                var aktifKaynaklar = await _unitOfWork.SuKaynaklari.FindAsync(x => x.AktifMi);
                return aktifKaynaklar.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Aktif su kaynakları getirilirken hata oluştu");
                throw;
            }
        }

        public async Task<SuAnaliz> GetSonSuAnalizAsync(int suKaynagiId)
        {
            try
            {
                var analizler = await _unitOfWork.SuAnalizleri.FindAsync(x => x.SuKaynagiId == suKaynagiId);
                return analizler.OrderByDescending(x => x.AnalizTarihi).FirstOrDefault()!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Son su analizi getirilirken hata oluştu. SuKaynagiId: {suKaynagiId}");
                throw;
            }
        }

        public async Task<List<SuAnaliz>> GetSuAnalizGecmisiAsync(int suKaynagiId, int kayitSayisi = 10)
        {
            try
            {
                var analizler = await _unitOfWork.SuAnalizleri.FindAsync(x => x.SuKaynagiId == suKaynagiId);
                return analizler.OrderByDescending(x => x.AnalizTarihi).Take(kayitSayisi).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Su analiz geçmişi getirilirken hata oluştu. SuKaynagiId: {suKaynagiId}");
                throw;
            }
        }

        public async Task<SuAnaliz> YeniSuAnalizEkleAsync(SuAnaliz suAnaliz)
        {
            try
            {
                suAnaliz.AnalizTarihi = DateTime.Now;
                suAnaliz.SuKalitesiSkoru = SuKalitesiSkoruHesapla(suAnaliz);
                suAnaliz.SulamayaUygun = suAnaliz.SuKalitesiSkoru >= 60;
                suAnaliz.OneriMetni = SulamaOnerisiOlustur(suAnaliz);

                await _unitOfWork.SuAnalizleri.AddAsync(suAnaliz);
                await _unitOfWork.SaveChangesAsync();

                await SuKaynagiDurumGuncelleAsync(suAnaliz.SuKaynagiId, suAnaliz.SulamayaUygun);

                _logger.LogInformation($"Yeni su analizi eklendi. ID: {suAnaliz.Id}, SuKaynagiId: {suAnaliz.SuKaynagiId}");
                return suAnaliz;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Yeni su analizi eklenirken hata oluştu");
                throw;
            }
        }

        public async Task<SuAnaliz> SuAnalizGuncelleAsync(SuAnaliz suAnaliz)
        {
            try
            {
                suAnaliz.SuKalitesiSkoru = SuKalitesiSkoruHesapla(suAnaliz);
                suAnaliz.SulamayaUygun = suAnaliz.SuKalitesiSkoru >= 60;
                suAnaliz.OneriMetni = SulamaOnerisiOlustur(suAnaliz);

                _unitOfWork.SuAnalizleri.Update(suAnaliz);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation($"Su analizi güncellendi. ID: {suAnaliz.Id}");
                return suAnaliz;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Su analizi güncellenirken hata oluştu. ID: {suAnaliz.Id}");
                throw;
            }
        }

        public async Task<bool> SuKalitesiDegerlendirAsync(int suAnalizId)
        {
            try
            {
                var suAnaliz = await _unitOfWork.SuAnalizleri.GetByIdAsync(suAnalizId);
                if (suAnaliz == null)
                    throw new Exception($"Su analizi bulunamadı. ID: {suAnalizId}");

                suAnaliz.SuKalitesiSkoru = SuKalitesiSkoruHesapla(suAnaliz);
                suAnaliz.SulamayaUygun = suAnaliz.SuKalitesiSkoru >= 60;
                suAnaliz.OneriMetni = SulamaOnerisiOlustur(suAnaliz);

                _unitOfWork.SuAnalizleri.Update(suAnaliz);
                await _unitOfWork.SaveChangesAsync();

                return suAnaliz.SulamayaUygun;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Su kalitesi değerlendirilirken hata oluştu. ID: {suAnalizId}");
                throw;
            }
        }

        public async Task<List<SuAnaliz>> GetKritikSuAnalizleriAsync()
        {
            try
            {
                var kritikAnalizler = await _unitOfWork.SuAnalizleri.FindAsync(x => x.SuKalitesiSkoru < 50);
                return kritikAnalizler.OrderBy(x => x.SuKalitesiSkoru).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kritik su analizleri getirilirken hata oluştu");
                throw;
            }
        }

        public async Task<bool> SuKaynagiDurumGuncelleAsync(int suKaynagiId, bool aktifMi)
        {
            try
            {
                var suKaynagi = await _unitOfWork.SuKaynaklari.GetByIdAsync(suKaynagiId);
                if (suKaynagi == null)
                    throw new Exception($"Su kaynağı bulunamadı. ID: {suKaynagiId}");

                suKaynagi.AktifMi = aktifMi;
                suKaynagi.SonGuncellemeTarihi = DateTime.Now;

                _unitOfWork.SuKaynaklari.Update(suKaynagi);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation($"Su kaynağı durumu güncellendi. ID: {suKaynagiId}, Aktif: {aktifMi}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Su kaynağı durumu güncellenirken hata oluştu. ID: {suKaynagiId}");
                throw;
            }
        }

        // ================= RAPORLAMA METOTLARI =================

        public async Task<RaporSonucu> SuRaporuOlusturAsync(int suKaynagiId, DateTime baslangic, DateTime bitis)
        {
            try
            {
                var suKaynagi = await GetSuKaynagiByIdAsync(suKaynagiId);
                var analizler = await _unitOfWork.SuAnalizleri.FindAsync(x =>
                                x.SuKaynagiId == suKaynagiId &&
                                x.AnalizTarihi >= baslangic &&
                                x.AnalizTarihi <= bitis);

                var analizListesi = analizler.OrderBy(x => x.AnalizTarihi).ToList();

                var rapor = new RaporSonucu
                {
                    Baslik = $"{suKaynagi.Ad} - Su Analiz Raporu",
                    OlusturmaTarihi = DateTime.Now,
                    BaslangicTarihi = baslangic,
                    BitisTarihi = bitis,
                    ToplamAnalizSayisi = analizListesi.Count,
                    OrtalamaSuKalitesi = analizListesi.Any() ? analizListesi.Average(x => x.SuKalitesiSkoru) : 0,
                    UygunlukOrani = analizListesi.Any() ? (double)analizListesi.Count(x => x.SulamayaUygun) / analizListesi.Count * 100 : 0,
                    DetayliRapor = SuRaporuDetaylariOlustur(analizListesi, suKaynagi),
                    SuKaynagiId = suKaynagiId,
                    RaporTipi = "SuAnaliz",
                    ToplamUygunAnaliz = analizListesi.Count(x => x.SulamayaUygun),
                    ToplamUygunOlmayanAnaliz = analizListesi.Count(x => !x.SulamayaUygun),
                    ToplamKritikAnaliz = analizListesi.Count(x => x.SuKalitesiSkoru < 50),
                    OrtalamaPH = analizListesi.Any() ? analizListesi.Average(x => x.pH) : 0,
                    OrtalamaEC = analizListesi.Any() ? analizListesi.Average(x => x.EC) : 0,
                    OrtalamaNitrat = analizListesi.Any() ? analizListesi.Average(x => x.Nitrat) : 0,
                    OrtalamaSodyum = analizListesi.Any() ? analizListesi.Average(x => x.Sodyum) : 0,
                    ParametrelerJson = System.Text.Json.JsonSerializer.Serialize(ParametreRaporuOlustur(analizListesi))
                };

                // Raporu veritabanına kaydet
                await _unitOfWork.RaporSonuclari.AddAsync(rapor);
                await _unitOfWork.SaveChangesAsync();

                return rapor;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Su raporu oluşturulurken hata oluştu. SuKaynagiId: {suKaynagiId}");
                throw;
            }
        }

        public async Task<RaporSonucuDto> SuRaporuDtoOlusturAsync(int suKaynagiId, DateTime baslangic, DateTime bitis)
        {
            var entity = await SuRaporuOlusturAsync(suKaynagiId, baslangic, bitis);
            var suKaynagi = await GetSuKaynagiByIdAsync(suKaynagiId);

            return new RaporSonucuDto
            {
                Id = entity.Id,
                Baslik = entity.Baslik,
                OlusturmaTarihi = entity.OlusturmaTarihi,
                BaslangicTarihi = entity.BaslangicTarihi,
                BitisTarihi = entity.BitisTarihi,
                ToplamAnalizSayisi = entity.ToplamAnalizSayisi,
                OrtalamaSuKalitesi = entity.OrtalamaSuKalitesi,
                UygunlukOrani = entity.UygunlukOrani,
                SuKalitesiSinifi = SuKaliteSinifiBelirle(entity.OrtalamaSuKalitesi),
                DetayliRapor = entity.DetayliRapor,
                ToplamKritikAnaliz = entity.ToplamKritikAnaliz,
                ToplamUygunAnaliz = entity.ToplamUygunAnaliz,
                ToplamUygunOlmayanAnaliz = entity.ToplamUygunOlmayanAnaliz,
                OrtalamaPH = entity.OrtalamaPH,
                OrtalamaEC = entity.OrtalamaEC,
                OrtalamaNitrat = entity.OrtalamaNitrat,
                OrtalamaSodyum = entity.OrtalamaSodyum,
                SuKaynagiId = suKaynagiId,
                SuKaynagiAdi = suKaynagi.Ad,
                RaporTipi = entity.RaporTipi,
                Parametreler = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(entity.ParametrelerJson) ?? new Dictionary<string, object>(),
                AktifMi = entity.AktifMi
            };
        }

        // ================= YARDIMCI METOTLAR =================

        private int SuKalitesiSkoruHesapla(SuAnaliz analiz)
        {
            int skor = 100;

            if (analiz.pH < 6.5 || analiz.pH > 7.5) skor -= 15;
            else if (analiz.pH < 6.0 || analiz.pH > 8.0) skor -= 30;

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

            return Math.Max(0, skor);
        }

        private string SulamaOnerisiOlustur(SuAnaliz analiz)
        {
            var oneri = new System.Text.StringBuilder();

            if (!analiz.SulamayaUygun)
            {
                oneri.AppendLine("⚠️ UYARI: Bu su kaynağı doğrudan sulama için UYGUN DEĞİLDİR!\n");
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

        private string SuRaporuDetaylariOlustur(List<SuAnaliz> analizler, SuKaynagi suKaynagi)
        {
            var detay = new System.Text.StringBuilder();
            detay.AppendLine($"=== {suKaynagi.Ad} RAPORU ===");
            detay.AppendLine($"Konum: {suKaynagi.Konum}");
            detay.AppendLine($"Kaynak Tipi: {suKaynagi.KaynakTipi}");
            detay.AppendLine($"Toplam Analiz: {analizler.Count}\n");

            if (analizler.Any())
            {
                var sonAnaliz = analizler.Last();
                detay.AppendLine("=== SON ANALİZ DEĞERLERİ ===");
                detay.AppendLine($"Tarih: {sonAnaliz.AnalizTarihi:dd.MM.yyyy}");
                detay.AppendLine($"pH: {sonAnaliz.pH:F2}");
                detay.AppendLine($"EC: {sonAnaliz.EC:F2} mS/cm");
                detay.AppendLine($"Nitrat: {sonAnaliz.Nitrat:F1} mg/L");
                detay.AppendLine($"Sodyum: {sonAnaliz.Sodyum:F1} mg/L");
                detay.AppendLine($"Su Kalite Skoru: {sonAnaliz.SuKalitesiSkoru}/100");
                detay.AppendLine($"Sulamaya Uygun: {(sonAnaliz.SulamayaUygun ? "Evet" : "Hayır")}");
            }

            return detay.ToString();
        }

        private Dictionary<string, object> ParametreRaporuOlustur(List<SuAnaliz> analizler)
        {
            if (!analizler.Any())
                return new Dictionary<string, object>();

            return new Dictionary<string, object>
            {
                ["pH_Ortalama"] = analizler.Average(x => x.pH),
                ["pH_Min"] = analizler.Min(x => x.pH),
                ["pH_Maks"] = analizler.Max(x => x.pH),
                ["EC_Ortalama"] = analizler.Average(x => x.EC),
                ["Nitrat_Ortalama"] = analizler.Average(x => x.Nitrat),
                ["Sodyum_Ortalama"] = analizler.Average(x => x.Sodyum),
                ["Klor_Ortalama"] = analizler.Average(x => x.Klor)
            };
        }

        private string SuKaliteSinifiBelirle(double skor)
        {
            return skor switch
            {
                >= 80 => "Mükemmel",
                >= 60 => "İyi",
                >= 40 => "Orta",
                >= 20 => "Kötü",
                _ => "Çok Kötü"
            };
        }
    }
}