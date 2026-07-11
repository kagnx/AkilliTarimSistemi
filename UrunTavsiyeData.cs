using Microsoft.ML.Data;

namespace AkilliTarimSistemi.ML.Models;

public class UrunTavsiyeData
{
    [LoadColumn(0)]
    public float Azot_ppm { get; set; } // Azot yerine Azot_ppm yaptık

    [LoadColumn(1)]
    public float Fosfor_ppm { get; set; } // Fosfor yerine Fosfor_ppm yaptık

    [LoadColumn(2)]
    public float Potasyum_ppm { get; set; } // Potasyum yerine Potasyum_ppm yaptık

    [LoadColumn(3)]
    public float pH { get; set; }

    [LoadColumn(4)]
    public float OrganikMadde { get; set; }

    [LoadColumn(5)]
    public float Tuzluluk { get; set; }

    [LoadColumn(6)]
    public string ToprakTuru { get; set; } = string.Empty;

    [LoadColumn(7)]
    public string UrunTipi { get; set; } = string.Empty;

    [LoadColumn(8)] 
    public float Kirec { get; set; }
}