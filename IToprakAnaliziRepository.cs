using AkilliTarimSistemi.Core.Entities;

namespace AkilliTarimSistemi.DAL.Repositories;

public interface IToprakAnalizRepository : IRepository<ToprakAnalizi>
{
    Task<IEnumerable<ToprakAnalizi>> GetByTarlaAdiAsync(string tarlaAdi);
    Task<IEnumerable<ToprakAnalizi>> GetByTarihRangeAsync(DateTime baslangic, DateTime bitis);
}