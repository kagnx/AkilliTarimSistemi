
namespace AkilliTarimSistemi.Core.DTOs;

public class UrunTavsiyesiDto
{
    // Eksik olan ve serviste kullandığın tüm alanları buraya ekliyoruz:
    public double Azot { get; set; }
    public double Fosfor { get; set; }
    public double Potasyum { get; set; }
    public double PH { get; set; }
    public double OrganikMadde { get; set; }
    public double Tuzluluk { get; set; }
    public string? ToprakTuru { get; set; } // Serviste string kullanıyorsun, burası string olmalı
    public string? TahminEdilenUrun { get; set; }
}