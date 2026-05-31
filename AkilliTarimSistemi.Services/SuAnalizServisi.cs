using AkilliTarimSistemi.Core.DTOs;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services
{
    public class SuAnalizServisi : ISuAnalizServisi
    {
        private readonly IUnitOfWork _unitOfWork;

        public SuAnalizServisi(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SuAnaliziDto>> GetAllAsync()
        {
            var list = await _unitOfWork.SuAnalizler.GetAllAsync();
            return list.Select(a => new SuAnaliziDto
            {
                Id = a.Id,
                TarlaId = a.TarlaId,
                TarlaAdi = a.Tarla?.TarlaAdi ?? "",
                AnalizTarihi = a.Tarih,
                UrunTipi = a.UrunTipi,
                SuKaynagi = a.Kaynak,
                pH = a.pH,
                ElektrikselIletkenlik_EC = a.EC,
                Sicaklik = 0,  // Entity'de yoksa
                Bulaniklik = 0,
                Klorur_Cl = a.Klor,
                Sülfat_SO4 = 0,
                Bikarbonat_HCO3 = 0,
                Karbonat_CO3 = 0,
                Nitrat_NO3 = a.Nitrat,
                Nitrit_NO2 = a.Nitrit,
                Kalsiyum_Ca = 0,
                Magnezyum_Mg = 0,
                Sodyum_Na = a.Sodyum,
                Potasyum_K = 0,
                Arsenik_As = 0,
                Kadmiyum_Cd = 0,
                Kursun_Pb = 0,
                Civa_Hg = 0,
                Krom_Cr = 0,
                Nikel_Ni = 0,
                SAR_SodyumAdsorpsiyonOrani = 0,
                RSC_ArtikSodyumKarbonat = 0,
                SSP_SodyumYuzdesi = 0,
                TuzlulukSinifi = "",
                AlkaliniteSinifi = "",
                KoliformBakteri = 0,
                EschericiaColi = 0,
                SulamaIcinUygunMu = a.SulamayaUygun,
                UygunlukAciklamasi = "",
                OnerilenTedavi = "",
                AnaliziYapanKullaniciId = 0,
                KayitTarihi = a.KayitTarihi,
                AktifMi = a.AktifMi
            }).ToList();
        }

        public async Task<SuAnaliziDto?> GetByIdAsync(int id)
        {
            var a = await _unitOfWork.SuAnalizler.GetByIdAsync(id);
            if (a == null) return null;
            return new SuAnaliziDto
            {
                Id = a.Id,
                TarlaId = a.TarlaId,
                TarlaAdi = a.Tarla?.TarlaAdi ?? "",
                AnalizTarihi = a.Tarih,
                UrunTipi = a.UrunTipi,
                SuKaynagi = a.Kaynak,
                pH = a.pH,
                ElektrikselIletkenlik_EC = a.EC,
                Klorur_Cl = a.Klor,
                Nitrat_NO3 = a.Nitrat,
                Nitrit_NO2 = a.Nitrit,
                Sodyum_Na = a.Sodyum,
                SulamaIcinUygunMu = a.SulamayaUygun,
                KayitTarihi = a.KayitTarihi,
                AktifMi = a.AktifMi
            };
        }

        public async Task AddAsync(SuAnaliziDto dto)
        {
            var entity = new SuAnalizi
            {
                Tarih = dto.AnalizTarihi,
                TarlaId = dto.TarlaId,
                UrunTipi = dto.UrunTipi,
                Kaynak = dto.SuKaynagi,
                pH = dto.pH,
                EC = dto.ElektrikselIletkenlik_EC,
                Klor = dto.Klorur_Cl,
                Nitrat = dto.Nitrat_NO3,
                Nitrit = dto.Nitrit_NO2,
                Sodyum = dto.Sodyum_Na,
                SulamayaUygun = dto.SulamaIcinUygunMu,
                KayitTarihi = dto.KayitTarihi,
                AktifMi = dto.AktifMi
            };
            await _unitOfWork.SuAnalizler.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(SuAnaliziDto dto)
        {
            var entity = await _unitOfWork.SuAnalizler.GetByIdAsync(dto.Id);
            if (entity == null) throw new System.Exception("Su analizi bulunamadı");
            entity.Tarih = dto.AnalizTarihi;
            entity.TarlaId = dto.TarlaId;
            entity.UrunTipi = dto.UrunTipi;
            entity.Kaynak = dto.SuKaynagi;
            entity.pH = dto.pH;
            entity.EC = dto.ElektrikselIletkenlik_EC;
            entity.Klor = dto.Klorur_Cl;
            entity.Nitrat = dto.Nitrat_NO3;
            entity.Nitrit = dto.Nitrit_NO2;
            entity.Sodyum = dto.Sodyum_Na;
            entity.SulamayaUygun = dto.SulamaIcinUygunMu;
            entity.KayitTarihi = dto.KayitTarihi;
            entity.AktifMi = dto.AktifMi;
            _unitOfWork.SuAnalizler.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.SuAnalizler.GetByIdAsync(id);
            if (entity != null)
            {
                _unitOfWork.SuAnalizler.Delete(entity);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}