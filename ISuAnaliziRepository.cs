using AkilliTarimSistemi.Core.Entities;

namespace AkilliTarimSistemi.DAL.Repositories;

public interface ISuAnalizRepository : IRepository<SuAnaliz>
{
    Task<IEnumerable<SuAnaliz>> GetByTarlaIdAsync(int tarlaId);
    Task<IEnumerable<SuAnaliz>> GetSulamayaUygunAsync(bool uygun);
}