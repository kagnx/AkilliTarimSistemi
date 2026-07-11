using Microsoft.EntityFrameworkCore;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.Context;

namespace AkilliTarimSistemi.DAL.Repositories;

public class SensorVerisiRepository : Repository<SensorVerisi>, ISensorVerisiRepository

{
    public async Task<IEnumerable<SensorVerisi>> GetByTarihRangeAsync(int tarlaId, DateTime baslangic, DateTime bitis)
    {
        return await _dbSet.Where(s => s.TarlaId == tarlaId && s.OkumaZamani >= baslangic && s.OkumaZamani <= bitis)
                           .ToListAsync();
    }

    public async Task<IEnumerable<SensorVerisi>> GetKritikNemOkuyanlarAsync(double nemEsik)
    {
        return await _dbSet.Where(s => s.ToprakNemi < nemEsik)
                           .OrderByDescending(s => s.OkumaZamani)
                           .ToListAsync();
    }
    public SensorVerisiRepository(AkilliTarimDbContext context) : base(context) { }

    public async Task<IEnumerable<SensorVerisi>> GetByTarlaIdAsync(int tarlaId)
        => await _dbSet.Where(s => s.TarlaId == tarlaId).ToListAsync();

    public async Task<SensorVerisi?> GetSonOkumaAsync(int tarlaId)
        => await _dbSet.Where(s => s.TarlaId == tarlaId)
                       .OrderByDescending(s => s.OkumaZamani)
                       .FirstOrDefaultAsync();
}