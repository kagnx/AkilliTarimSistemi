using AkilliTarimSistemi.Core.DTOs;

public interface ISuAnalizServisi
{
    Task<IEnumerable<SuAnaliziDto>> GetAllAsync();
    Task<SuAnaliziDto?> GetByIdAsync(int id);
    Task AddAsync(SuAnaliziDto dto);
    Task UpdateAsync(SuAnaliziDto dto);
    Task DeleteAsync(int id);
}