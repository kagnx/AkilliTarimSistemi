using System;
using AkilliTarimSistemi.Core.Enums;

namespace AkilliTarimSistemi.Core.DTOs
{
    public class YaprakAnaliziDto
    {
        public int Id { get; set; }
        public DateTime AnalizTarihi { get; set; }

        // Bitki ve Tarla Bilgileri
        public UrunTipi UrunTipi { get; set; }
        public string? UrunAdi => UrunTipi.ToString();
        public int? TarlaId { get; set; }
        public string? TarlaAdi { get; set; }


        // Makro Besin Elementleri (ppm veya %)
        public double Azot_N { get; set; }      // Azot (ppm veya %)
        public double Fosfor_P { get; set; }    // Fosfor (ppm)
        public double Potasyum_K { get; set; }  // Potasyum (ppm)

        // İkincil Makro Besinler
        public double Kalsiyum_Ca { get; set; } // Kalsiyum (%)
        public double Magnezyum_Mg { get; set; } // Magnezyum (%)
        public double Kükürt_S { get; set; }    // Kükürt (ppm)

        // Mikro Besin Elementleri (ppm veya ppb)
        public double Demir_Fe { get; set; }    // Demir (ppm)
        public double Cinko_Zn { get; set; }    // Çinko (ppm)
        public double Mangan_Mn { get; set; }   // Mangan (ppm)
        public double Bakir_Cu { get; set; }    // Bakır (ppm)
        public double Bor_B { get; set; }       // Bor (ppm)
        public double Molibden_Mo { get; set; } // Molibden (ppm)

        // Fizyolojik Parametreler
        public double KlorofilSeviyesi { get; set; }   // SPAD değeri (0-100)
        public double YaprakSicakligi { get; set; }     // °C
        public double YaprakNemi { get; set; }          // %

        // Görsel Değerlendirme
        public string? Renk { get; set; }                // Açık yeşil, koyu yeşil, sarı vs.
        public BitkiBesinEksikligi EksiklikBelirtisi { get; set; }
        public string? EksiklikAciklamasi => EksiklikBelirtisi.ToString();

        // Zararlı / Hastalık Tespiti
        public bool ZararliVarMi { get; set; }
        public string? ZararliTuru { get; set; }
        public string? HastalikAdi { get; set; }

        // Genel Değerlendirme
        public string? Degerlendirme { get; set; }
        public string? Oneriler { get; set; }

        // Kullanıcı / Teknisyen Bilgisi
        public int AnaliziYapanKullaniciId { get; set; }

        // Sistem Yönetimi
        public DateTime KayitTarihi { get; set; }
        public bool AktifMi { get; set; } = true;
    }
}