using AkilliTarimSistemi.Core.Enums;

namespace AkilliTarimSistemi.Core.Entities;

public class UrunTavsiyesi : BaseEntity
{
    public int TarlaId { get; set; }                     // Eksikti
    public DateTime TavsiyeTarihi { get; set; }
    public UrunTipi TavsiyeEdilenUrun { get; set; }
    public double GuvenSkoru { get; set; }
    public string? Gerekce { get; set; }
    public bool UygulandiMi { get; set; }                // Eksikti

    public virtual Tarla? Tarla { get; set; }
}