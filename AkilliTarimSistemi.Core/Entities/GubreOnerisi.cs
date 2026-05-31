using AkilliTarimSistemi.Core.Enums;

namespace AkilliTarimSistemi.Core.Entities;

public class GubreOnerisi : BaseEntity
{
    public int TarlaId { get; set; }                     // Eksikti
    public DateTime OneriTarihi { get; set; }
    public UrunTipi HedefUrun { get; set; }              // Eksikti
    public double OnerilenAzot { get; set; }
    public double OnerilenFosfor { get; set; }
    public double OnerilenPotasyum { get; set; }
    public string? OnerilenGubreCesidi { get; set; }
    public string? UygulamaZamani { get; set; }
    public bool UygulandiMi { get; set; }

    // Navigation
    public virtual Tarla? Tarla { get; set; }
}