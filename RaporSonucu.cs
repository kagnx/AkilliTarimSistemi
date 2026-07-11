using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkilliTarimSistemi.Core.Entities
{
    /// <summary>
    /// Rapor sonuçları entity'si - Veritabanında saklanır
    /// </summary>
    [Table("RaporSonuclari")]
    public class RaporSonucu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Baslik { get; set; } = string.Empty;

        [Required]
        public DateTime OlusturmaTarihi { get; set; }

        [Required]
        public DateTime BaslangicTarihi { get; set; }

        [Required]
        public DateTime BitisTarihi { get; set; }

        [Required]
        public int ToplamAnalizSayisi { get; set; }

        public double OrtalamaSuKalitesi { get; set; }

        public double UygunlukOrani { get; set; }

        [StringLength(50)]
        public string SuKalitesiSinifi { get; set; } = string.Empty;

        [StringLength(50)]
        public string RaporTipi { get; set; } = "SuAnaliz"; // SuAnaliz, ToprakAnaliz, VerimTahmini vb.

        public int? SuKaynagiId { get; set; }
        public int? TarlaId { get; set; }
        public int? OlusturanKullaniciId { get; set; }

        [Column(TypeName = "TEXT")]
        public string DetayliRapor { get; set; } = string.Empty;

        [Column(TypeName = "TEXT")]
        public string Ozet { get; set; } = string.Empty;

        [Column(TypeName = "TEXT")]
        public string Oneriler { get; set; } = string.Empty;

        public int ToplamKritikAnaliz { get; set; }
        public int ToplamUygunAnaliz { get; set; }
        public int ToplamUygunOlmayanAnaliz { get; set; }

        public double OrtalamaPH { get; set; }
        public double OrtalamaEC { get; set; }
        public double OrtalamaNitrat { get; set; }
        public double OrtalamaSodyum { get; set; }

        public bool AktifMi { get; set; } = true;
        public DateTime? GuncellemeTarihi { get; set; }

        // Navigasyon property'leri
        [ForeignKey("SuKaynagiId")]
        public virtual SuKaynagi? SuKaynagi { get; set; }

        [ForeignKey("TarlaId")]
        public virtual Tarla? Tarla { get; set; }

        // Rapor parametreleri JSON olarak saklanabilir
        [Column(TypeName = "TEXT")]
        public string ParametrelerJson { get; set; } = "{}";

        // Rapor dosya yolu (PDF/Excel)
        [StringLength(500)]
        public string DosyaYolu { get; set; } = string.Empty;

        [StringLength(50)]
        public string DosyaFormat { get; set; } = string.Empty; // PDF, EXCEL, CSV
    }

    /// <summary>
    /// Farklı rapor tipleri için enum
    /// </summary>
    public enum RaporTipi
    {
        SuAnaliz = 1,
        ToprakAnaliz = 2,
        VerimTahmini = 3,
        GubreOnerisi = 4,
        UrunTavsiye = 5,
        GenelPerformans = 6
    }

    /// <summary>
    /// Rapor durumu enum'u
    /// </summary>
    public enum RaporDurumu
    {
        Hazirlaniyor = 1,
        Tamamlandi = 2,
        Hata = 3,
        Iptal = 4
    }
}