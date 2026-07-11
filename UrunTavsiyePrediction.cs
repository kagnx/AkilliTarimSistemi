using Microsoft.ML.Data;

namespace AkilliTarimSistemi.ML.Models;

public class UrunTavsiyePrediction
{
    [ColumnName("PredictedLabel")]
    public string PredictedLabel { get; set; } = string.Empty; // Uyarı CS8618 çözümü için default değer atadık

    public float[]? Score { get; set; } // Uyarı CS8618 çözümü için nullable (?) yaptık
}