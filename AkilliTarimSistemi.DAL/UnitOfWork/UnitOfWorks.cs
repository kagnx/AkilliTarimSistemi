using AkilliTarimSistemi.DAL.Context;
using AkilliTarimSistemi.DAL.Repositories;
using Microsoft.EntityFrameworkCore; // DbUpdateException için bu namespace'in eklendiğinden emin ol

namespace AkilliTarimSistemi.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AkilliTarimDbContext _context;

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

    public async Task<int> CompleteAsync()
    {
        try
        {
            // Değişiklikleri kaydetmeyi dener ve etkilenen satır sayısını döner
            return await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            // SQLite Foreign Key hatası düştüğünde hangi entity'nin patladığını loglar
            foreach (var entry in ex.Entries)
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, Durum: {entry.State}");

                foreach (var property in entry.CurrentValues.Properties)
                {
                    Console.WriteLine($" - {property.Name}: {entry.CurrentValues[property]}");
                }
            }

            // Hatayı yukarıya (Business/Controller katmanına) fırlatmaya devam eder
            throw;
        }
    }

    public void Dispose() => _context.Dispose();
}