using Microsoft.EntityFrameworkCore;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.Context;

namespace AkilliTarimSistemi.DAL.Repositories;

public class YaprakAnalizRepository : Repository<YaprakAnalizi>, IYaprakAnalizRepository
{
    public YaprakAnalizRepository(AkilliTarimDbContext context) : base(context) { }

    public async Task<IEnumerable<YaprakAnalizi>> GetByTarlaIdAsync(int tarlaId)
        => await _dbSet.Where(y => y.TarlaId == tarlaId).ToListAsync();

    public async Task<IEnumerable<YaprakAnalizi>> GetByTarihRangeAsync(DateTime baslangic, DateTime bitis)
        => await _dbSet.Where(y => y.Tarih >= baslangic && y.Tarih <= bitis).ToListAsync();
}