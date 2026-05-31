using AkilliTarimSistemi.Core.Entities;

namespace AkilliTarimSistemi.DAL.Repositories;

/// <summary>
/// Sensör verileri için özel repository interface'i
/// </summary>
public interface ISensorVerisiRepository : IRepository<SensorVerisi>
{
    /// <summary>
    /// Belirli bir tarlaya ait tüm sensör verilerini getirir
    /// </summary>
    /// <param name="tarlaId">Tarla ID</param>
    /// <returns>Sensör verileri listesi</returns>
    Task<IEnumerable<SensorVerisi>> GetByTarlaIdAsync(int tarlaId);

    /// <summary>
    /// Belirli bir tarlanın en son sensör okumasını getirir
    /// </summary>
    /// <param name="tarlaId">Tarla ID</param>
    /// <returns>En güncel sensör verisi veya null</returns>
    Task<SensorVerisi?> GetSonOkumaAsync(int tarlaId);

    /// <summary>
    /// Belirli bir tarih aralığındaki sensör verilerini getirir
    /// </summary>
    /// <param name="tarlaId">Tarla ID</param>
    /// <param name="baslangic">Başlangıç tarihi</param>
    /// <param name="bitis">Bitiş tarihi</param>
    /// <returns>Sensör verileri listesi</returns>
    Task<IEnumerable<SensorVerisi>> GetByTarihRangeAsync(int tarlaId, DateTime baslangic, DateTime bitis);

    /// <summary>
    /// Toprak nemi belirli bir eşik değerin altında olan son okumaları getirir
    /// (Sulama ihtiyacı kontrolü için)
    /// </summary>
    /// <param name="nemEsik">Nem eşik değeri (%)</param>
    /// <returns>Sensör verileri listesi</returns>
    Task<IEnumerable<SensorVerisi>> GetKritikNemOkuyanlarAsync(double nemEsik);
}