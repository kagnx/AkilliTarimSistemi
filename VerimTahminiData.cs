using Microsoft.ML.Data;

namespace AkilliTarimSistemi.ML
{
    public class VerimTahminiData
    {
        [LoadColumn(0)] public float Azot { get; set; }
        [LoadColumn(1)] public float Fosfor { get; set; }
        [LoadColumn(2)] public float Potasyum { get; set; }
        [LoadColumn(3)] public float pH { get; set; }
        [LoadColumn(4)] public float OrganikMadde { get; set; }
        [LoadColumn(5)] public float Tuzluluk { get; set; }

        // Nullable uyarılarını engellemek için = string.Empty atıyoruz
        [LoadColumn(6)] public string ToprakTuru { get; set; } = string.Empty;
        [LoadColumn(7)] public string UrunTipi { get; set; } = string.Empty;

        [LoadColumn(8)] public float Yagis_mm { get; set; }
        [LoadColumn(9)] public float Sicaklik_Ort { get; set; }
        [LoadColumn(10)] public bool SulamaYapildiMi { get; set; }
        [LoadColumn(11)] public bool Gubreleme_TamMi { get; set; }

        // Hatanın sebebi burasıydı: İsimi tam olarak aşağıda yazıldığı gibi kullan
        [LoadColumn(12)] public float GecmisVerim_kg { get; set; }
        [LoadColumn(13)] public string? UrunAdi { get; set; }
    }
}