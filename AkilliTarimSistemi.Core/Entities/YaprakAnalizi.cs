using AkilliTarimSistemi.Core.Enums;

namespace AkilliTarimSistemi.Core.Entities;

public class YaprakAnalizi : BaseEntity
{
    public int? TarlaId { get; set; }                     // Eksikti
    public DateTime Tarih { get; set; }                  // Eksikti
    public UrunTipi UrunTipi { get; set; }          // Yeni eklendi
    
    public double AzotYaprak { get; set; }
    public double FosforYaprak { get; set; }
    public double PotasyumYaprak { get; set; }
    public double Demir { get; set; }
    public double Cinko { get; set; }
    public double Mangan { get; set; }
    public double Bakir { get; set; }
    public BitkiBesinEksikligi? GozlenenEksiklik { get; set; }
    public string? GorselNot { get; set; }

    public virtual Tarla? Tarla { get; set; }
}