using Microsoft.EntityFrameworkCore;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.Context;

namespace AkilliTarimSistemi.DAL.Repositories;

public class VerimTahminiRepository : Repository<VerimTahmini>, IVerimTahminiRepository
{
    public VerimTahminiRepository(AkilliTarimDbContext context) : base(context) { }

    public async Task<IEnumerable<VerimTahmini>> GetByTarlaIdAsync(int tarlaId)
        => await _dbSet.Where(v => v.TarlaId == tarlaId).ToListAsync();

    public async Task<VerimTahmini?> GetEnGuncelTahminAsync(int tarlaId)
        => await _dbSet.Where(v => v.TarlaId == tarlaId)
                       .OrderByDescending(v => v.TahminTarihi)
                       .FirstOrDefaultAsync();
}