using AkilliTarimSistemi.DAL.Repositories;

namespace AkilliTarimSistemi.DAL.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IToprakAnalizRepository ToprakAnalizler { get; }        // Düzeltildi
    IYaprakAnalizRepository YaprakAnalizler { get; }
    ISuAnalizRepository SuAnalizler { get; }
    ISensorVerisiRepository SensorVeriler { get; }
    IUrunTavsiyesiRepository UrunTavsiyeler { get; }
    IGubreOnerisiRepository GubreOneriler { get; }
    IVerimTahminiRepository VerimTahminler { get; }
    ITarlaRepository Tarlalar { get; }
    IKullaniciRepository Kullanicilar { get; }
    Task<int> CompleteAsync();
}