namespace AkilliTarimSistemi.ML.Models;

public class UrunTavsiyePrediction
{
    public float PredictedLabel { get; set; }
    public float[] Score { get; set; } = Array.Empty<float>();
}