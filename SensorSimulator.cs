using System.Timers;  // Timer'ın hangi namespace'ten geldiğini belirt
using Timer = System.Timers.Timer;  // Alias ile çakışmayı önle

namespace AkilliTarimSistemi.IoT
{
    public class SensorSimulator : ISensorDataProvider
    {
        private Timer? _timer;
        private readonly Random _random = new();
        private bool _isRunning;

        public event EventHandler<SensorDataEventArgs>? DataReceived;

        public void Start()
        {
            if (_isRunning) return;
            _timer = new Timer(2000);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Start();
            _isRunning = true;
        }

        public void Stop()
        {
            _timer?.Stop();
            _timer?.Dispose();
            _isRunning = false;
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {
            var args = new SensorDataEventArgs
            {
                Timestamp = DateTime.Now,
                Sicaklik = _random.Next(150, 350) / 10.0,
                Nem = _random.Next(400, 800) / 10.0,
                ToprakNemi = _random.Next(200, 700) / 10.0,
                IsikSiddeti = _random.Next(0, 1000),
                PH = _random.Next(60, 85) / 10.0,
                CO2 = _random.Next(350, 800)
            };
            DataReceived?.Invoke(this, args);
        }
    }
}