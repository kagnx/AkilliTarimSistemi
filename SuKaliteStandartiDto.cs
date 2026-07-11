using AkilliTarimSistemi.Core.Enums;


namespace AkilliTarimSistemi.Core.DTOs
{
    public class SuKaliteStandarti
    {
        public double IdefalpHMin { get; set; } = 6.5;
        public double IdefalpHMax { get; set; } = 7.5;
        public double MaksimumEC { get; set; } = 2.0;
        public double MaksimumNitrat { get; set; } = 25;
        public double MaksimumNitrit { get; set; } = 0.03;
        public double MaksimumSodyum { get; set; } = 50;
        public double MaksimumKlor { get; set; } = 100;
    }
}