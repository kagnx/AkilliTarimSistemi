using AkilliTarimSistemi.Core.Entities;

namespace AkilliTarimSistemi.DAL.Repositories;

public interface ISuAnalizRepository : IRepository<SuAnalizi>
{
    Task<IEnumerable<SuAnalizi>> GetByTarlaIdAsync(int tarlaId);
    Task<IEnumerable<SuAnalizi>> GetSulamayaUygunAsync(bool uygun);
}