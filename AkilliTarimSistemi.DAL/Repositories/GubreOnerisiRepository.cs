using Microsoft.EntityFrameworkCore;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.Context;

namespace AkilliTarimSistemi.DAL.Repositories;

public class GubreOnerisiRepository : Repository<GubreOnerisi>, IGubreOnerisiRepository
{
    public GubreOnerisiRepository(AkilliTarimDbContext context) : base(context) { }

    public async Task<IEnumerable<GubreOnerisi>> GetByTarlaIdAsync(int tarlaId)
        => await _dbSet.Where(g => g.TarlaId == tarlaId).ToListAsync();

    public async Task<IEnumerable<GubreOnerisi>> GetByUrunTipiAsync(int urunTipiId)
        => await _dbSet.Where(g => (int)g.HedefUrun == urunTipiId).ToListAsync();
}