using Microsoft.EntityFrameworkCore;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.Context;

namespace AkilliTarimSistemi.DAL.Repositories;

public class KullaniciRepository : Repository<Kullanici>, IKullaniciRepository
{
    public KullaniciRepository(AkilliTarimDbContext context) : base(context) { }

    public async Task<Kullanici?> GetByEmailAsync(string email)
        => await _dbSet.FirstOrDefaultAsync(k => k.Email == email);

    public async Task<IEnumerable<Kullanici>> GetByRolAsync(string rol)
        => await _dbSet.Where(k => k.Rol == rol).ToListAsync();
}