using Microsoft.ML.Data;

namespace AkilliTarimSistemi.ML.Models;

public class GubreOnerisiData
{
    [LoadColumn(0)] public float pH { get; set; }
    [LoadColumn(1)] public float Azot_ppm { get; set; }
    [LoadColumn(2)] public float Fosfor_ppm { get; set; }
    [LoadColumn(3)] public float Potasyum_ppm { get; set; }
    [LoadColumn(4)] public float OrganikMadde { get; set; }
    [LoadColumn(5)] public float ToprakTuru { get; set; }
    [LoadColumn(6)] public float UrunTipi { get; set; }
    [LoadColumn(7)] public float OnerilenAzot { get; set; }
    [LoadColumn(8)] public float OnerilenFosfor { get; set; }
    [LoadColumn(9)] public float OnerilenPotasyum { get; set; }
    public float GecmisVerim_kg { get; set; }
}