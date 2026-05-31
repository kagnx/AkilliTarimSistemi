using AkilliTarimSistemi.Core.Enums;
using System;

namespace AkilliTarimSistemi.Core.DTOs
{
    public class SuAnaliziDto
    {
        public int Id { get; set; }
        public DateTime AnalizTarihi { get; set; }

        // Kaynak Bilgisi
        public int? TarlaId { get; set; }
        public string? TarlaAdi { get; set; }
        public UrunTipi UrunTipi { get; set; }          // YENİ EKLENDİ
        public string? SuKaynagi { get; set; } // Kuyu, Dere, Gölet, Baraj, Şebeke

        // Temel Fiziksel / Kimyasal Parametreler
        public double pH { get; set; }               // 0-14 arası
        public double ElektrikselIletkenlik_EC { get; set; } // dS/m veya µS/cm
        public double Sicaklik { get; set; }         // °C
        public double Bulaniklik { get; set; }       // NTU

        // Anyonlar (mg/L veya ppm)
        public double Klorur_Cl { get; set; }
        public double Sülfat_SO4 { get; set; }
        public double Bikarbonat_HCO3 { get; set; }
        public double Karbonat_CO3 { get; set; }
        public double Nitrat_NO3 { get; set; }
        public double Nitrit_NO2 { get; set; }

        // Katyonlar (mg/L veya ppm)
        public double Kalsiyum_Ca { get; set; }
        public double Magnezyum_Mg { get; set; }
        public double Sodyum_Na { get; set; }
        public double Potasyum_K { get; set; }

        // Ağır Metaller (mg/L veya µg/L)
        public double Arsenik_As { get; set; }      // mg/L
        public double Kadmiyum_Cd { get; set; }
        public double Kursun_Pb { get; set; }
        public double Civa_Hg { get; set; }
        public double Krom_Cr { get; set; }
        public double Nikel_Ni { get; set; }

        // Sulama Suyu Kalite İndeksleri
        public double SAR_SodyumAdsorpsiyonOrani { get; set; } // Sodium Adsorption Ratio
        public double RSC_ArtikSodyumKarbonat { get; set; }    // Residual Sodium Carbonate
        public double SSP_SodyumYuzdesi { get; set; }          // Soluble Sodium Percentage (%)

        // Su Sınıflandırması (Tuzluluk & Alkalinite)
        public string? TuzlulukSinifi { get; set; }   // C1-C4 (Düşük - Çok Yüksek)
        public string? AlkaliniteSinifi { get; set; } // S1-S4 (Düşük - Çok Yüksek)

        // Mikrobiyolojik Parametreler (Opsiyonel)
        public int KoliformBakteri { get; set; }     // EMS/100 mL
        public int EschericiaColi { get; set; }      // EMS/100 mL

        // Uygunluk Değerlendirmesi
        public bool SulamaIcinUygunMu { get; set; }
        public string? UygunlukAciklamasi { get; set; } // İyi, Orta, Riskli, Uygun Değil
        public string? OnerilenTedavi { get; set; }     // Filtreleme, Asitlendirme, Seyreltme vs.

        // Yetkili Bilgileri
        public int AnaliziYapanKullaniciId { get; set; }

        public DateTime KayitTarihi { get; set; }
        public bool AktifMi { get; set; } = true;
    }
}