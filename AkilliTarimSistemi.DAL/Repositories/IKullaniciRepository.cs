using AkilliTarimSistemi.Core.Entities;

namespace AkilliTarimSistemi.DAL.Repositories;

public interface IKullaniciRepository : IRepository<Kullanici>
{
    Task<Kullanici?> GetByEmailAsync(string email);
    Task<IEnumerable<Kullanici>> GetByRolAsync(string rol);
}