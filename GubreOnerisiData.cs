using Microsoft.ML.Data;

namespace AkilliTarimSistemi.ML.Models
{
    public class GubreOnerisiData
    {
        [LoadColumn(0)] public float pH { get; set; }
        [LoadColumn(1)] public float Azot_ppm { get; set; }
        [LoadColumn(2)] public float Fosfor_ppm { get; set; }
        [LoadColumn(3)] public float Potasyum_ppm { get; set; }
        [LoadColumn(4)] public float OrganikMadde { get; set; }

        [LoadColumn(5)] public float Tuzluluk{ get; set; }
        [LoadColumn(6)] public float GecmisVerim_kg { get; set; }

        // BUNLAR ARTIK STRING OLMALI (OneHotEncoding için)
        [LoadColumn(7)] public string ToprakTuru { get; set; } = string.Empty;
        [LoadColumn(8)] public string UrunTipi { get; set; } = string.Empty;

        // Çıktı Etiketleri (Labels)
        [LoadColumn(9)] public float OnerilenAzot { get; set; }
        [LoadColumn(10)] public float OnerilenFosfor { get; set; }
        [LoadColumn(11)] public float OnerilenPotasyum { get; set; }
    }
}