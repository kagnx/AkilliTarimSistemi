using AkilliTarimSistemi.Core.Enums;

namespace AkilliTarimSistemi.Core.Entities;

public class VerimTahmini : BaseEntity
{
    public int TarlaId { get; set; }                     // Eksikti
    public DateTime TahminTarihi { get; set; }
    public UrunTipi UrunTipi { get; set; }
    public double TahminiVerim { get; set; }
    public double AltLimit { get; set; }
    public double UstLimit { get; set; }
    public double GuvenSkoru { get; set; }
    public string? KullanilanModel { get; set; }

    public virtual Tarla? Tarla { get; set; }
}