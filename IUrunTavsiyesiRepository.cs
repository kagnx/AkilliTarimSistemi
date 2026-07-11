using AkilliTarimSistemi.Core.Entities;

namespace AkilliTarimSistemi.DAL.Repositories;

public interface IUrunTavsiyesiRepository : IRepository<UrunTavsiyesi>
{
    Task<IEnumerable<UrunTavsiyesi>> GetByTarlaIdAsync(int tarlaId);
    Task<IEnumerable<UrunTavsiyesi>> GetUygulanmayanlarAsync();
}