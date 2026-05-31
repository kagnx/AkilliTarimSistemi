using System;
using AkilliTarimSistemi.Core.Enums;

namespace AkilliTarimSistemi.Core.Entities
{
    public class ToprakAnalizi : BaseEntity
    {
        // İsteğe Bağlı Tarla İlişkisi (Sistemi bağımlılıktan kurtaran kritik alan)
        //public int? TarlaId { get; set; }

        public DateTime Tarih { get; set; }
        public UrunTipi UrunTipi { get; set; }
        public ToprakTipi ToprakTipi { get; set; }
        public int TarlaId { get; set; }                     // Eksikti
        // Kimya ve C# standartlarına göre pH mülk isimlendirmesi düzeltildi
        public double pH { get; set; }
        public double Azot { get; set; }
        public double Fosfor { get; set; }
        public double Potasyum { get; set; }
        public double Kalsiyum { get; set; }
        public double Magnezyum { get; set; }
        public double OrganikMadde { get; set; }
        public double Tuzluluk { get; set; }
        public string? Notlar { get; set; }

        // CRITICAL FIX: "= null!;" ifadesi kaldırıldı ve Tarla? (Nullable) yapıldı.
        // Böylece Entity Framework veritabanında tarlası olmayan bağımsız analizlere izin verecek.
        public virtual Tarla? Tarla { get; set; }
    }
}