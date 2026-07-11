using System.IO.Ports;

namespace AkilliTarimSistemi.IoT;

public class SerialPortReader : ISensorDataProvider, IDisposable
{
    private SerialPort? _serialPort;
    private bool _disposed;

    public event EventHandler<SensorDataEventArgs>? DataReceived;
    public string PortName { get; set; } = "COM3";
    public int BaudRate { get; set; } = 9600;

    public void Start()
    {
        if (_serialPort != null && _serialPort.IsOpen) return;
        _serialPort = new SerialPort(PortName, BaudRate);
        _serialPort.DataReceived += SerialPort_DataReceived;
        _serialPort.Open();
    }

    public void Stop()
    {
        if (_serialPort != null && _serialPort.IsOpen)
        {
            _serialPort.DataReceived -= SerialPort_DataReceived;
            _serialPort.Close();
        }
    }

    private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        if (_serialPort == null) return;
        string line = _serialPort.ReadLine();
        // Beklenen format: "25.5,65.2,30.1,550,7.2,410"
        var parts = line.Split(',');
        if (parts.Length >= 3)
        {
            var args = new SensorDataEventArgs
            {
                Timestamp = DateTime.Now,
                Sicaklik = double.TryParse(parts[0], out double s) ? s : 0,
                Nem = double.TryParse(parts[1], out double n) ? n : 0,
                ToprakNemi = double.TryParse(parts[2], out double tn) ? tn : 0,
                IsikSiddeti = parts.Length > 3 && double.TryParse(parts[3], out double i) ? i : 0,
                PH = parts.Length > 4 && double.TryParse(parts[4], out double ph) ? ph : null,
                CO2 = parts.Length > 5 && double.TryParse(parts[5], out double co2) ? co2 : null
            };
            DataReceived?.Invoke(this, args);
        }
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            Stop();
            _serialPort?.Dispose();
            _disposed = true;
        }
    }
}