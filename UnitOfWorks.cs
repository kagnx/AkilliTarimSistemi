using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.Context;
using AkilliTarimSistemi.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AkilliTarimSistemi.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AkilliTarimDbContext _context;
    private readonly Dictionary<Type, object> _repositories; // Repository cache için

    // Lazy loading için özel alanlar
    private IRepository<SuKaynagi>? _suKaynaklari;
    private IRepository<SuAnaliz>? _suAnalizleri;
    private IRepository<RaporSonucu>? _raporSonuclari;
    

    public IRepository<SuKaynagi> SuKaynaklari => _suKaynaklari ??= new Repository<SuKaynagi>(_context);
    public IRepository<SuAnaliz> SuAnalizleri => _suAnalizleri ??= new Repository<SuAnaliz>(_context);
    public IRepository<RaporSonucu> RaporSonuclari => _raporSonuclari ??= new Repository<RaporSonucu>(_context);

    // Diğer Repositoryler
    public IToprakAnalizRepository ToprakAnalizler { get; private set; }
    public IYaprakAnalizRepository YaprakAnalizler { get; private set; }
    public ISuAnalizRepository SuAnalizler { get; private set; }
    public ISensorVerisiRepository SensorVeriler { get; private set; }
    public IUrunTavsiyesiRepository UrunTavsiyeler { get; private set; }
    public IGubreOnerisiRepository GubreOneriler { get; private set; }
    public IVerimTahminiRepository VerimTahminler { get; private set; }
    public ITarlaRepository Tarlalar { get; private set; }
    public IKullaniciRepository Kullanicilar { get; private set; }

    public UnitOfWork(AkilliTarimDbContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();

        // Mevcut repositorylerin başlatılması
        ToprakAnalizler = new ToprakAnalizRepository(_context);
        YaprakAnalizler = new YaprakAnalizRepository(_context);
        SuAnalizler = new SuAnalizRepository(_context);
        SensorVeriler = new SensorVerisiRepository(_context);
        UrunTavsiyeler = new UrunTavsiyesiRepository(_context);
        GubreOneriler = new GubreOnerisiRepository(_context);
        VerimTahminler = new VerimTahminiRepository(_context);
        Tarlalar = new TarlaRepository(_context);
        Kullanicilar = new KullaniciRepository(_context);
    }

    /// <summary>
    /// Generic repository getirir (cache'li)
    /// </summary>
    private IRepository<T> GetRepository<T>() where T : class
    {
        if (_repositories.ContainsKey(typeof(T)))
            return (IRepository<T>)_repositories[typeof(T)];

        var repository = new Repository<T>(_context);
        _repositories.Add(typeof(T), repository);
        return repository;
    }

    /// <summary>
    /// Include işlemleriyle birlikte tüm kayıtları getirir
    /// </summary>
    public async Task<IEnumerable<T>> GetAllIncludingAsync<T>(
        params Expression<Func<T, object>>[] includeProperties) where T : class
    {
        var repository = GetRepository<T>();
        var query = repository.GetQueryable();

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return await query.ToListAsync();
    }

    /// <summary>
    /// Filtre ve Include ile kayıtları getirir
    /// </summary>
    public async Task<IEnumerable<T>> GetIncludingAsync<T>(
        Expression<Func<T, bool>>? filter = null,
        params Expression<Func<T, object>>[] includeProperties) where T : class
    {
        var repository = GetRepository<T>();
        var query = repository.GetQueryable();

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.ToListAsync();
    }

    /// <summary>
    /// Tek bir kayıt getirir (Include ile)
    /// </summary>
    public async Task<T?> GetSingleIncludingAsync<T>(
        Expression<Func<T, bool>> filter,
        params Expression<Func<T, object>>[] includeProperties) where T : class
    {
        var repository = GetRepository<T>();
        var query = repository.GetQueryable();

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return await query.FirstOrDefaultAsync(filter);
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    public async Task<int> CompleteAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            // Hata detaylarını logla
            foreach (var entry in ex.Entries)
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, Durum: {entry.State}");
            }
            throw;
        }
    }

    public void Dispose() => _context.Dispose();
}