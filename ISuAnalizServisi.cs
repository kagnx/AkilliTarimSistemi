using AkilliTarimSistemi.Core.DTOs;

namespace AkilliTarimSistemi.Services
{
    public interface ISuAnalizServisi
    {
        Task<IEnumerable<SuAnalizDto>> GetAllAsync();
        Task<SuAnalizDto?> GetByIdAsync(int id);
        Task<SuAnalizDto?> GetByTarlaIdAsync(int tarlaId);
        Task<IEnumerable<SuAnalizDto>> GetByTarihAraligiAsync(DateTime baslangic, DateTime bitis);
        Task<SuAnalizDto> AddAsync(SuAnalizDto dto);
        Task<SuAnalizDto> UpdateAsync(SuAnalizDto dto);
        Task DeleteAsync(int id);
        Task<bool> SuKalitesiniDegerlendirAsync(int id);
        Task<IEnumerable<SuAnalizDto>> GetUygunOlmayanAnalizlerAsync();
        Task<SuIstatistikDto> GetIstatistiklerAsync();
    }
}