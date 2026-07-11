using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.Repositories;
using System.Linq.Expressions;

namespace AkilliTarimSistemi.DAL.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    // Repository'ler
    IToprakAnalizRepository ToprakAnalizler { get; }
    IYaprakAnalizRepository YaprakAnalizler { get; }
    ISuAnalizRepository SuAnalizler { get; }
    ISensorVerisiRepository SensorVeriler { get; }
    IUrunTavsiyesiRepository UrunTavsiyeler { get; }
    IGubreOnerisiRepository GubreOneriler { get; }
    IVerimTahminiRepository VerimTahminler { get; }
    ITarlaRepository Tarlalar { get; }
    IKullaniciRepository Kullanicilar { get; }

    IRepository<SuKaynagi> SuKaynaklari { get; }
    IRepository<SuAnaliz> SuAnalizleri { get; }
    IRepository<RaporSonucu> RaporSonuclari { get; }

    // Include'li sorgulama metodları
    Task<IEnumerable<T>> GetAllIncludingAsync<T>(
        params Expression<Func<T, object>>[] includeProperties) where T : class;

    Task<IEnumerable<T>> GetIncludingAsync<T>(
        Expression<Func<T, bool>>? filter = null,
        params Expression<Func<T, object>>[] includeProperties) where T : class;

    Task<T?> GetSingleIncludingAsync<T>(
        Expression<Func<T, bool>> filter,
        params Expression<Func<T, object>>[] includeProperties) where T : class;

    // Database işlemleri
    Task<int> SaveChangesAsync();
    Task<int> CompleteAsync();
}