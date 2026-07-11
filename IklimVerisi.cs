using System;

namespace AkilliTarimSistemi.Core.Entities
{
    public class IklimVerisi : BaseEntity
    {
        public string Bolge { get; set; } = string.Empty;
        public DateTime Tarih { get; set; }
        public double OrtSicaklik { get; set; }
        public double MaxSicaklik { get; set; }
        public double MinSicaklik { get; set; }
        public double YagisMiktari { get; set; }   // mm
        public double NemOrtalama { get; set; }    // %
        public int GuneslenmeSuresi { get; set; }  // saat
        public string? Kaynak { get; set; }        // API adı
    }
}