using AkilliTarimSistemi.Core.Enums;

namespace AkilliTarimSistemi.Core.Entities;

public class SuAnalizi : BaseEntity
{
    public int? TarlaId { get; set; }                     // Eksikti
    public DateTime Tarih { get; set; }
    public UrunTipi UrunTipi { get; set; }          // Yeni eklendi
    public double pH { get; set; }
    public double EC { get; set; }
    public double Sertlik { get; set; }
    public double Nitrat { get; set; }
    public double Nitrit { get; set; }
    public double Sodyum { get; set; }
    public double Klor { get; set; }
    public string? Kaynak { get; set; }
    public bool SulamayaUygun { get; set; }              // Eksikti
    public DateTime KayitTarihi { get; set; } = DateTime.Now;
    public bool AktifMi { get; set; } = true;
    public virtual Tarla? Tarla { get; set; }
}