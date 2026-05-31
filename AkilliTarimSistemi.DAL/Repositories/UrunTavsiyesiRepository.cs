using Microsoft.EntityFrameworkCore;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.Context;

namespace AkilliTarimSistemi.DAL.Repositories;

public class UrunTavsiyesiRepository : Repository<UrunTavsiyesi>, IUrunTavsiyesiRepository
{
    public UrunTavsiyesiRepository(AkilliTarimDbContext context) : base(context) { }

    public async Task<IEnumerable<UrunTavsiyesi>> GetByTarlaIdAsync(int tarlaId)
        => await _dbSet.Where(u => u.TarlaId == tarlaId).ToListAsync();

    public async Task<IEnumerable<UrunTavsiyesi>> GetUygulanmayanlarAsync()
        => await _dbSet.Where(u => !u.UygulandiMi).ToListAsync();
}