using System;
using System.Collections.Generic;

namespace AkilliTarimSistemi.Core.DTOs
{
    /// <summary>
    /// Rapor sonuçları DTO'su - UI/API katmanları arasında veri transferi için
    /// </summary>
    public class RaporSonucuDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; } = string.Empty;
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }

        // İstatistiksel bilgiler
        public int ToplamAnalizSayisi { get; set; }
        public double OrtalamaSuKalitesi { get; set; }
        public double UygunlukOrani { get; set; }
        public string SuKalitesiSinifi { get; set; } = string.Empty;

        // Detaylı bilgiler
        public string DetayliRapor { get; set; } = string.Empty;
        public string Ozet { get; set; } = string.Empty;
        public string Oneriler { get; set; } = string.Empty;

        // Sayısal özetler
        public int ToplamKritikAnaliz { get; set; }
        public int ToplamUygunAnaliz { get; set; }
        public int ToplamUygunOlmayanAnaliz { get; set; }

        // Ortalama değerler
        public double OrtalamaPH { get; set; }
        public double OrtalamaEC { get; set; }
        public double OrtalamaNitrat { get; set; }
        public double OrtalamaSodyum { get; set; }
        public double OrtalamaKlor { get; set; }

        // Filtre bilgileri
        public int? SuKaynagiId { get; set; }
        public string? SuKaynagiAdi { get; set; }
        public int? TarlaId { get; set; }
        public string? TarlaAdi { get; set; }
        public string RaporTipi { get; set; } = "SuAnaliz";

        // Parametreler
        public Dictionary<string, object> Parametreler { get; set; } = new();

        // Dosya bilgileri
        public string? DosyaYolu { get; set; }
        public string? DosyaFormat { get; set; }

        // Durum
        public bool AktifMi { get; set; }
        public DateTime? GuncellemeTarihi { get; set; }

        // Yardımcı property'ler (hesaplanan)
        public string TarihAraligi => $"{BaslangicTarihi:dd.MM.yyyy} - {BitisTarihi:dd.MM.yyyy}";

        public string UygunlukDurumu => UygunlukOrani switch
        {
            >= 80 => "🟢 Mükemmel",
            >= 60 => "🟡 İyi",
            >= 40 => "🟠 Orta",
            >= 20 => "🔴 Kötü",
            _ => "⚫ Çok Kötü"
        };

        public string KaliteRengi => OrtalamaSuKalitesi switch
        {
            >= 80 => "Green",
            >= 60 => "YellowGreen",
            >= 40 => "Orange",
            >= 20 => "DarkOrange",
            _ => "Red"
        };

        public double KritikOran => ToplamAnalizSayisi > 0
            ? (double)ToplamKritikAnaliz / ToplamAnalizSayisi * 100
            : 0;
    }

    /// <summary>
    /// Rapor oluşturma isteği DTO'su
    /// </summary>
    public class RaporOlusturmaIstegiDto
    {
        public string Baslik { get; set; } = string.Empty;
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public int? SuKaynagiId { get; set; }
        public int? TarlaId { get; set; }
        public string RaporTipi { get; set; } = "SuAnaliz";
        public bool PdfOlustur { get; set; } = false;
        public bool ExcelOlustur { get; set; } = false;
        public Dictionary<string, object> EkParametreler { get; set; } = new();
    }

    /// <summary>
    /// Rapor listesi görüntüleme DTO'su
    /// </summary>
    public class RaporListeDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; } = string.Empty;
        public DateTime OlusturmaTarihi { get; set; }
        public string RaporTipi { get; set; } = string.Empty;
        public string SuKalitesiSinifi { get; set; } = string.Empty;
        public double OrtalamaSuKalitesi { get; set; }
        public int ToplamAnalizSayisi { get; set; }
        public string? SuKaynagiAdi { get; set; }
        public string? TarlaAdi { get; set; }
        public string TarihAraligi { get; set; } = string.Empty;
        public string DurumRengi { get; set; } = string.Empty;
    }

    /// <summary>
    /// Rapor istatistik DTO'su
    /// </summary>
    public class RaporIstatistikDto
    {
        public int ToplamRaporSayisi { get; set; }
        public int BuAyRaporSayisi { get; set; }
        public int BuHaftaRaporSayisi { get; set; }
        public double OrtalamaRaporSkoru { get; set; }
        public Dictionary<string, int> RaporTipiDagilimi { get; set; } = new();
        public Dictionary<string, int> KaliteSinifiDagilimi { get; set; } = new();
        public List<RaporListeDto> SonRaporlar { get; set; } = new();
    }
}