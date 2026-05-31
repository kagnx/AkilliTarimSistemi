using Microsoft.ML.Data;

namespace AkilliTarimSistemi.ML.Models;

public class VerimTahminiData
{
    [LoadColumn(0)] public float pH { get; set; }
    [LoadColumn(1)] public float OrganikMadde { get; set; }
    [LoadColumn(2)] public float Tuzluluk { get; set; }
    [LoadColumn(3)] public float ToprakTuru { get; set; }
    [LoadColumn(4)] public float UrunTipi { get; set; }
    [LoadColumn(5)] public float Yagis_mm { get; set; }
    [LoadColumn(6)] public float Sicaklik_ort { get; set; }
    [LoadColumn(7)] public float SulamaYapildiMi { get; set; }
    [LoadColumn(8)] public float Gubreleme_TamMi { get; set; }
    [LoadColumn(9)] public float GecmisVerim_kg { get; set; }
}