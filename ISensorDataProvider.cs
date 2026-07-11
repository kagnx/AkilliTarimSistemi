namespace AkilliTarimSistemi.IoT;

public interface ISensorDataProvider
{
    event EventHandler<SensorDataEventArgs>? DataReceived;
    void Start();
    void Stop();
}

public class SensorDataEventArgs : EventArgs
{
    public DateTime Timestamp { get; set; }
    public double Sicaklik { get; set; }      // °C
    public double Nem { get; set; }           // % hava nemi
    public double ToprakNemi { get; set; }    // %
    public double IsikSiddeti { get; set; }   // lüx
    public double? PH { get; set; }
    public double? CO2 { get; set; }
}