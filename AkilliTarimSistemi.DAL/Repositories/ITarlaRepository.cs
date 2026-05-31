using AkilliTarimSistemi.Core.Entities;

namespace AkilliTarimSistemi.DAL.Repositories;

public interface ITarlaRepository : IRepository<Tarla>
{
    Task<IEnumerable<Tarla>> GetByKullaniciIdAsync(int kullaniciId);
    Task<Tarla?> GetTarlaWithAnalizlerAsync(int tarlaId);
}