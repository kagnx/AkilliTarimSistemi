using AkilliTarimSistemi.Core.Enums;

namespace AkilliTarimSistemi.Core.Entities
{
    public class VerimTahmini : BaseEntity
    {
        public int TarlaId { get; set; }

        // Girdi Parametreleri
        public double Azot { get; set; }
        public double Fosfor { get; set; }
        public double Potasyum { get; set; }
        public double PH { get; set; }
        public double OrganikMadde { get; set; }
        public double Tuzluluk { get; set; }
        public double Yagis_mm { get; set; }
        public double Sicaklik_Ort { get; set; }
        public bool SulamaYapildiMi { get; set; }
        public bool Gubreleme_TamMi { get; set; }

        // Sonuçlar (Bunları sadece bir kez burada tanımla!)
        public DateTime TahminTarihi { get; set; }
        public UrunTipi UrunTipi { get; set; }
        public double TahminiVerim { get; set; }
        public double AltLimit { get; set; }
        public double UstLimit { get; set; }
        public double GuvenSkoru { get; set; }
        public string? KullanilanModel { get; set; }

        public virtual Tarla? Tarla { get; set; }
    }
}


