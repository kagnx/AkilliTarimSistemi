using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.Core.Enums;
using AkilliTarimSistemi.DAL.UnitOfWork;
using AkilliTarimSistemi.IoT;
using Microsoft.Extensions.DependencyInjection; // 1. Bu namespace'i MUTLAKA ekle

namespace AkilliTarimSistemi.Services;

public class IoTSensorService : IIoTSensorService, IDisposable
{
    private readonly IServiceProvider _serviceProvider; // 2. Doğrudan tek bir UnitOfWork yerine servis sağlayıcıyı alıyoruz
    private readonly ISensorDataProvider _sensorProvider;
    private int _currentTarlaId;
    private bool _isMonitoring;

    public event EventHandler<SensorVerisi>? NewSensorDataReceived;

    // Constructor'da IServiceProvider kabul ediyoruz
    public IoTSensorService(IServiceProvider serviceProvider, ISensorDataProvider sensorProvider)
    {
        _serviceProvider = serviceProvider;
        _sensorProvider = sensorProvider;
        _sensorProvider.DataReceived += OnSensorDataReceived;
    }

    public void StartMonitoring(int tarlaId)
    {
        _currentTarlaId = tarlaId;
        _isMonitoring = true;
        _sensorProvider.Start();
    }

    public void StopMonitoring()
    {
        _sensorProvider.Stop();
        _isMonitoring = false;
        _currentTarlaId = 0; // İzleme durduğunda ID'yi sıfırla ki sahte veri yazmasın
    }

    private async void OnSensorDataReceived(object? sender, SensorDataEventArgs e)
    {
        // 3. KRİTİK GÜVENLİK: İzleme açık değilse VEYA tarla ID'si geçersizse (0 veya eksi) ASLA ilerleme!
        if (!_isMonitoring || _currentTarlaId <= 0) return;

        try
        {
            // 4. THREAD SAFETY: Her yeni sensör verisi geldiğinde izole, taze bir bağımlılık alanı açıyoruz
            using (var scope = _serviceProvider.CreateScope())
            {
                // Bu taze alandan temiz bir UnitOfWork üretiyoruz (Çakışmaları önler)
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                var sensorData = new SensorVerisi
                {
                    TarlaId = _currentTarlaId,
                    OkumaZamani = e.Timestamp,
                    Sicaklik = e.Sicaklik,
                    Nem = e.Nem,
                    ToprakNemi = e.ToprakNemi,
                    IsikSiddeti = e.IsikSiddeti,
                    pH = e.PH,
                    Co2 = e.CO2,
                    SulamaDurumu = SulamaDurumu.Kapali
                };

                // Veritabanına kaydetme işlemi
                await unitOfWork.SensorVeriler.AddAsync(sensorData);
                await unitOfWork.CompleteAsync();

                // UI katmanına (Forma) verinin ulaştığını haber ver
                NewSensorDataReceived?.Invoke(this, sensorData);
            }
        }
        catch (Exception ex)
        {
            // Arka plandaki patlamaları sessizce yutmaması için loglayalım veya debug'da görelim
            System.Diagnostics.Debug.WriteLine($"Sensör Veri Kayıt Hatası: {ex.Message}");
        }
    }

    public async Task<SensorVerisi?> GetLastSensorDataAsync(int tarlaId)
    {
        // Okuma işlemi için yine taze bir scope açmak en temizidir
        using (var scope = _serviceProvider.CreateScope())
        {
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var all = await unitOfWork.SensorVeriler.GetByTarlaIdAsync(tarlaId);
            return all?.OrderByDescending(s => s.OkumaZamani).FirstOrDefault();
        }
    }

    public void Dispose()
    {
        StopMonitoring();
        _sensorProvider.DataReceived -= OnSensorDataReceived; // Bellek sızıntısını önlemek için un-subscribe
        (_sensorProvider as IDisposable)?.Dispose();
    }
}