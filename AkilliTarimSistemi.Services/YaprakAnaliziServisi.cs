using AkilliTarimSistemi.Core.DTOs;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.Core.Enums;
using AkilliTarimSistemi.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services
{
    public class YaprakAnaliziServisi : IYaprakAnaliziServisi
    {
        private readonly IUnitOfWork _unitOfWork;

        public YaprakAnaliziServisi(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<YaprakAnaliziDto>> GetAllAsync()
        {
            var list = await _unitOfWork.YaprakAnalizler.GetAllAsync();
            return list.Select(a => new YaprakAnaliziDto
            {
                Id = a.Id,
                AnalizTarihi = a.Tarih,
                UrunTipi = a.UrunTipi,
                TarlaId = a.TarlaId,
                TarlaAdi = a.Tarla?.TarlaAdi ?? "",
                // Makro besinler
                Azot_N = a.AzotYaprak,
                Fosfor_P = a.FosforYaprak,
                Potasyum_K = a.PotasyumYaprak,
                // Mikro besinler
                Demir_Fe = a.Demir,
                Cinko_Zn = a.Cinko,
                Mangan_Mn = a.Mangan,
                Bakir_Cu = a.Bakir,
                // Diğer alanlar entity'de yoksa varsayılan
                Kalsiyum_Ca = 0,
                Magnezyum_Mg = 0,
                Kükürt_S = 0,
                Bor_B = 0,
                Molibden_Mo = 0,
                KlorofilSeviyesi = 0,
                YaprakSicakligi = 0,
                YaprakNemi = 0,
                Renk = "",
                EksiklikBelirtisi = a.GozlenenEksiklik ?? BitkiBesinEksikligi.Yok,
                ZararliVarMi = false,
                ZararliTuru = "",
                HastalikAdi = "",
                Degerlendirme = "",
                Oneriler = "",
                AnaliziYapanKullaniciId = 0,
                KayitTarihi = DateTime.Now,
                AktifMi = true
            }).ToList();
        }

        public async Task<YaprakAnaliziDto?> GetByIdAsync(int id)
        {
            var a = await _unitOfWork.YaprakAnalizler.GetByIdAsync(id);
            if (a == null) return null;
            return new YaprakAnaliziDto
            {
                Id = a.Id,
                AnalizTarihi = a.Tarih,
                UrunTipi = a.UrunTipi,
                TarlaId = a.TarlaId,
                TarlaAdi = a.Tarla?.TarlaAdi ?? "",
                Azot_N = a.AzotYaprak,
                Fosfor_P = a.FosforYaprak,
                Potasyum_K = a.PotasyumYaprak,
                Demir_Fe = a.Demir,
                Cinko_Zn = a.Cinko,
                Mangan_Mn = a.Mangan,
                Bakir_Cu = a.Bakir,
                EksiklikBelirtisi = a.GozlenenEksiklik ?? BitkiBesinEksikligi.Yok,
                KayitTarihi = DateTime.Now,
                AktifMi = true
            };
        }

        public async Task AddAsync(YaprakAnaliziDto dto)
        {
            var entity = new YaprakAnalizi
            {
                TarlaId = dto.TarlaId,
                Tarih = dto.AnalizTarihi,
                UrunTipi = dto.UrunTipi,
                AzotYaprak = dto.Azot_N,
                FosforYaprak = dto.Fosfor_P,
                PotasyumYaprak = dto.Potasyum_K,
                Demir = dto.Demir_Fe,
                Cinko = dto.Cinko_Zn,
                Mangan = dto.Mangan_Mn,
                Bakir = dto.Bakir_Cu,
                GozlenenEksiklik = dto.EksiklikBelirtisi
            };
            await _unitOfWork.YaprakAnalizler.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(YaprakAnaliziDto dto)
        {
            var entity = await _unitOfWork.YaprakAnalizler.GetByIdAsync(dto.Id);
            if (entity == null) throw new System.Exception("Yaprak analizi bulunamadı");
            entity.TarlaId = dto.TarlaId;
            entity.Tarih = dto.AnalizTarihi;
            entity.UrunTipi = dto.UrunTipi;
            entity.AzotYaprak = dto.Azot_N;
            entity.FosforYaprak = dto.Fosfor_P;
            entity.PotasyumYaprak = dto.Potasyum_K;
            entity.Demir = dto.Demir_Fe;
            entity.Cinko = dto.Cinko_Zn;
            entity.Mangan = dto.Mangan_Mn;
            entity.Bakir = dto.Bakir_Cu;
            entity.GozlenenEksiklik = dto.EksiklikBelirtisi;
            _unitOfWork.YaprakAnalizler.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.YaprakAnalizler.GetByIdAsync(id);
            if (entity != null)
            {
                _unitOfWork.YaprakAnalizler.Delete(entity);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}