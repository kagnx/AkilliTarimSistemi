using AkilliTarimSistemi.Core.Entities;

namespace AkilliTarimSistemi.Services;

public interface IIoTSensorService
{
    event EventHandler<SensorVerisi>? NewSensorDataReceived;
    void StartMonitoring(int tarlaId);
    void StopMonitoring();
    Task<SensorVerisi?> GetLastSensorDataAsync(int tarlaId);
}