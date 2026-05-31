using AkilliTarimSistemi.Core.Entities;

namespace AkilliTarimSistemi.DAL.Repositories;

public interface IVerimTahminiRepository : IRepository<VerimTahmini>
{
    Task<IEnumerable<VerimTahmini>> GetByTarlaIdAsync(int tarlaId);
    Task<VerimTahmini?> GetEnGuncelTahminAsync(int tarlaId);
}