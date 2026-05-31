using AkilliTarimSistemi.Core.Entities;

namespace AkilliTarimSistemi.DAL.Repositories;

public interface IGubreOnerisiRepository : IRepository<GubreOnerisi>
{
    Task<IEnumerable<GubreOnerisi>> GetByTarlaIdAsync(int tarlaId);
    Task<IEnumerable<GubreOnerisi>> GetByUrunTipiAsync(int urunTipiId);
}