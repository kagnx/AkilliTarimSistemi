using Microsoft.EntityFrameworkCore;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.Context;

namespace AkilliTarimSistemi.DAL.Repositories;

public class SuAnalizRepository : Repository<SuAnalizi>, ISuAnalizRepository
{
    public SuAnalizRepository(AkilliTarimDbContext context) : base(context) { }

    public async Task<IEnumerable<SuAnalizi>> GetByTarlaIdAsync(int tarlaId)
        => await _dbSet.Where(s => s.TarlaId == tarlaId).ToListAsync();

    public async Task<IEnumerable<SuAnalizi>> GetSulamayaUygunAsync(bool uygun)
        => await _dbSet.Where(s => s.SulamayaUygun == uygun).ToListAsync();
}