using AkilliTarimSistemi.Core.Enums;

namespace AkilliTarimSistemi.Core.DTOs;

public class VerimTahminiDto
{
    public int Id { get; set; }
    public int TarlaId { get; set; }
    public string? TarlaAdi { get; set; }
    public DateTime TahminTarihi { get; set; }
    public UrunTipi UrunTipi { get; set; }
    public double pH { get; set; }
    public double Azot { get; set; }        // Eklendi
    public double Fosfor { get; set; }      // Eklendi
    public double Potasyum { get; set; }    // Eklendi
    public double OrganikMadde { get; set; }
    public double Tuzluluk { get; set; }
    public int ToprakTuru { get; set; }             // enum değeri
    public double Yagis_mm { get; set; }
    public float Sicaklik_Ort { get; set; }
    public bool SulamaYapildiMi { get; set; }
    public bool Gubreleme_TamMi { get; set; }
    public bool GecmisVerimVarMi { get; set; }
    public double TahminiVerim { get; set; }        // kg/da – sonuç
    public double AltLimit { get; set; }
    public double UstLimit { get; set; }
    public double GuvenSkoru { get; set; }
}