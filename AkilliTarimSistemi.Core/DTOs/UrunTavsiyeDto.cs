using AkilliTarimSistemi.Core.Enums;

namespace AkilliTarimSistemi.Core.DTOs;

public class UrunTavsiyesiDto
{
    public int Id { get; set; }
    public int TarlaId { get; set; }
    public string? TarlaAdi { get; set; }           // UI'da göstermek için
    public DateTime TavsiyeTarihi { get; set; }
    public UrunTipi TavsiyeEdilenUrun { get; set; }
    public double GuvenSkoru { get; set; }           // 0-100 arası
    public string? Gerekce { get; set; }             // Modelin açıklaması
    public bool UygulandiMi { get; set; }
}