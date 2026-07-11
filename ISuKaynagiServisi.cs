using AkilliTarimSistemi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services
{
    /// <summary>
    /// Su kaynakları ve su analizleri yönetim servisi
    /// </summary>
    public interface ISuKaynagiServisi
    {
        Task<SuKaynagi> GetSuKaynagiByIdAsync(int id);
        Task<List<SuKaynagi>> GetAllSuKaynaklariAsync();
        Task<List<SuKaynagi>> GetAktifSuKaynaklariAsync();
        Task<SuAnaliz> GetSonSuAnalizAsync(int suKaynagiId);
        Task<List<SuAnaliz>> GetSuAnalizGecmisiAsync(int suKaynagiId, int kayitSayisi = 10);
        Task<SuAnaliz> YeniSuAnalizEkleAsync(SuAnaliz suAnaliz);
        Task<SuAnaliz> SuAnalizGuncelleAsync(SuAnaliz suAnaliz);
        Task<bool> SuKalitesiDegerlendirAsync(int suAnalizId);
        Task<List<SuAnaliz>> GetKritikSuAnalizleriAsync();
        Task<bool> SuKaynagiDurumGuncelleAsync(int suKaynagiId, bool aktifMi);

        // RaporSonucu sınıfını muhtemelen DTO olarak veya SuKaynagiServisi dosyasının altında tanımladığın için burada kullanılabilir.
        Task<RaporSonucu> SuRaporuOlusturAsync(int suKaynagiId, DateTime baslangic, DateTime bitis);
    }
}