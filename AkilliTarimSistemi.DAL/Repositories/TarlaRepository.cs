using Microsoft.EntityFrameworkCore;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.Context;

namespace AkilliTarimSistemi.DAL.Repositories;

public class TarlaRepository : Repository<Tarla>, ITarlaRepository
{
    public TarlaRepository(AkilliTarimDbContext context) : base(context) { }

    public async Task<IEnumerable<Tarla>> GetByKullaniciIdAsync(int kullaniciId)
        => await _dbSet.Where(t => t.KullaniciId == kullaniciId).ToListAsync();

    public async Task<Tarla?> GetTarlaWithAnalizlerAsync(int tarlaId)
        => await _dbSet.Include(t => t.ToprakAnalizleri)
                       .Include(t => t.YaprakAnalizleri)
                       .Include(t => t.SuAnalizleri)
                       .Include(t => t.SensorVerileri)
                       .FirstOrDefaultAsync(t => t.Id == tarlaId);
}