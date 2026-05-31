using Microsoft.ML.Data;

namespace AkilliTarimSistemi.ML.Models;

public class UrunTavsiyeData
{
    [LoadColumn(0)] public float pH { get; set; }
    [LoadColumn(1)] public float Azot { get; set; }
    [LoadColumn(2)] public float Fosfor { get; set; }
    [LoadColumn(3)] public float Potasyum { get; set; }
    [LoadColumn(4)] public float OrganikMadde { get; set; }
    [LoadColumn(5)] public float Tuzluluk { get; set; }
    [LoadColumn(6)] public float ToprakTuru { get; set; }
    [LoadColumn(7)] public float UrunTipi { get; set; }
}