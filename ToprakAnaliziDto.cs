
using AkilliTarimSistemi.Core.Enums;

namespace AkilliTarimSistemi.Core.DTOs
{
    public class ToprakAnaliziDto
    {
        public int Id { get; set; }
        public int TarlaId { get; set; }
        public string? TarlaAdi { get; set; }
        public DateTime AnalizTarihi { get; set; }
        public ToprakTipi ToprakTipi { get; set; }
        public UrunTipi UrunTipi { get; set; }          // YENİ EKLENDİ
        public double pH { get; set; }
        public double ElektrikselIletkenlik { get; set; }
        public double OrganikMadde { get; set; }
        public float Tuzluluk { get; set; } = 0.0f;
        public double Azot { get; set; }
        public double Fosfor { get; set; }
        public double Potasyum { get; set; }
        public double Demir { get; set; }
        public double Cinko { get; set; }
        public string? Degerlendirme { get; set; }
        public string? OnerilenGubre { get; set; }
        public int AnaliziYapanKullaniciId { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}