using Microsoft.EntityFrameworkCore;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.Context;

namespace AkilliTarimSistemi.DAL.Repositories;

public class ToprakAnalizRepository : Repository<ToprakAnalizi>, IToprakAnalizRepository
{
    public ToprakAnalizRepository(AkilliTarimDbContext context) : base(context) { }

    public async Task<IEnumerable<ToprakAnalizi>> GetByTarlaAdiAsync(string tarlaAdi)
        => await _dbSet.Include(t => t.Tarla)
                       .Where(t => t.Tarla != null && t.Tarla.TarlaAdi == tarlaAdi)
                       .ToListAsync();

    public async Task<IEnumerable<ToprakAnalizi>> GetByTarihRangeAsync(DateTime baslangic, DateTime bitis)
        => await _dbSet.Where(t => t.Tarih >= baslangic && t.Tarih <= bitis).ToListAsync();
}