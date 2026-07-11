using AkilliTarimSistemi.Core.Entities;

namespace AkilliTarimSistemi.DAL.Repositories;

public interface IYaprakAnalizRepository : IRepository<YaprakAnalizi>
{
    Task<IEnumerable<YaprakAnalizi>> GetByTarlaIdAsync(int tarlaId);
    Task<IEnumerable<YaprakAnalizi>> GetByTarihRangeAsync(DateTime baslangic, DateTime bitis);
}