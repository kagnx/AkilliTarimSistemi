using AkilliTarimSistemi.Core.Enums;

namespace AkilliTarimSistemi.Core.DTOs;

public class GubreOnerisiDto
{
    public int Id { get; set; }
    public int TarlaId { get; set; }
    public string? TarlaAdi { get; set; }           // UI'da göstermek için
    public DateTime OneriTarihi { get; set; }
    public UrunTipi HedefUrun { get; set; }
    public double OnerilenAzot { get; set; }        // kg/da
    public double OnerilenFosfor { get; set; }      // kg/da
    public double OnerilenPotasyum { get; set; }    // kg/da
    public string? OnerilenGubreCesidi { get; set; } // Örn: "15-15-15"
    public string? UygulamaZamani { get; set; }      // Örn: "Ekim öncesi"
    public bool UygulandiMi { get; set; }
}