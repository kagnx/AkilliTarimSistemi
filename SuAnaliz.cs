using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkilliTarimSistemi.Core.Entities
{
    [Table("SuAnalizler")]
    public class SuAnaliz
    {
        [Key]
        public int Id { get; set; }

        // Temel Bilgiler
        public DateTime AnalizTarihi { get; set; }
        public int SuKaynagiId { get; set; }
        public int? TarlaId { get; set; }

        [StringLength(100)]
        public string? UrunTipi { get; set; }  // ✅ EKLENDİ

        [StringLength(200)]
        public string? Kaynak { get; set; }  // ✅ EKLENDİ (Su kaynağı adı)

        // Fiziksel Parametreler
        public double pH { get; set; }
        public double EC { get; set; }  // Elektriksel İletkenlik
        public double Sicaklik { get; set; }  // ✅ EKLENDİ (Sıcaklık)
        public double Bulaniklik { get; set; }  // ✅ EKLENDİ
        public double Sertlik { get; set; }  // ✅ EKLENDİ

        // Anyonlar
        public double Klor { get; set; }
        public double Sulfat { get; set; }  // ✅ EKLENDİ (SO4)
        public double Bikarbonat { get; set; }  // ✅ EKLENDİ (HCO3)
        public double Karbonat { get; set; }  // ✅ EKLENDİ (CO3)
        public double Nitrat { get; set; }
        public double Nitrit { get; set; }

        // Katyonlar
        public double Kalsiyum { get; set; }  // ✅ EKLENDİ (Ca)
        public double Magnezyum { get; set; }  // ✅ EKLENDİ (Mg)
        public double Sodyum { get; set; }
        public double Potasyum { get; set; }  // ✅ EKLENDİ (K)

        // Ağır Metaller
        public double Arsenik { get; set; }  // ✅ EKLENDİ (As)
        public double Kadmiyum { get; set; }  // ✅ EKLENDİ (Cd)
        public double Kursun { get; set; }  // ✅ EKLENDİ (Pb)
        public double Civa { get; set; }  // ✅ EKLENDİ (Hg)
        public double Krom { get; set; }  // ✅ EKLENDİ (Cr)
        public double Nikel { get; set; }  // ✅ EKLENDİ (Ni)

        // Su Kalitesi Endeksleri
        public double SAR { get; set; }  // ✅ EKLENDİ (Sodyum Adsorpsiyon Oranı)
        public double RSC { get; set; }  // ✅ EKLENDİ (Artık Sodyum Karbonat)
        public double SSP { get; set; }  // ✅ EKLENDİ (Sodyum Yüzdesi)

        [StringLength(50)]
        public string? TuzlulukSinifi { get; set; }  // ✅ EKLENDİ

        [StringLength(50)]
        public string? AlkaliniteSinifi { get; set; }  // ✅ EKLENDİ

        // Biyolojik Parametreler
        public int KoliformBakteri { get; set; }  // ✅ EKLENDİ
        public int EscherichiaColi { get; set; }  // ✅ EKLENDİ

        // Değerlendirme Sonuçları
        public int SuKalitesiSkoru { get; set; }
        public bool SulamayaUygun { get; set; }

        [Column(TypeName = "TEXT")]
        public string? OneriMetni { get; set; }

        [Column(TypeName = "TEXT")]
        public string? OnerilenTedavi { get; set; }  // ✅ EKLENDİ

        // Kayıt Bilgileri
        public int? AnaliziYapanKullaniciId { get; set; }  // ✅ EKLENDİ
        public DateTime KayitTarihi { get; set; }  // ✅ EKLENDİ
        public DateTime? GuncellemeTarihi { get; set; }
        public bool AktifMi { get; set; }  // ✅ EKLENDİ

        // Navigasyon Property'leri
        [ForeignKey("SuKaynagiId")]
        public virtual SuKaynagi? SuKaynagi { get; set; }

        [ForeignKey("TarlaId")]
        public virtual Tarla? Tarla { get; set; }
    }
}