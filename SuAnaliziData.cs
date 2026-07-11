using Microsoft.ML.Data;

namespace AkilliTarimSistemi.ML.Models
{
    public class SuAnaliziData
    {
        [LoadColumn(0)] public float pH { get; set; }
        [LoadColumn(1)] public float EC { get; set; }
        [LoadColumn(2)] public float Sertlik { get; set; }
        [LoadColumn(3)] public float Nitrat { get; set; }
        [LoadColumn(4)] public float Nitrit { get; set; }
        [LoadColumn(5)] public float Sodyum { get; set; }
        [LoadColumn(6)] public float Klor { get; set; }

        [LoadColumn(7), ColumnName("Label")]
        public bool SulamayaUygun { get; set; }
    }

    public class SuOnerisiPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool SulamayaUygun { get; set; }

        [ColumnName("Probability")]
        public float Probability { get; set; }

        [ColumnName("Score")]
        public float Score { get; set; }

        public string OneriMetni
        {
            get
            {
                if (SulamayaUygun)
                {
                    return $"🌱 [SULAMAYA UYGUN]\nAnaliz değerleri standartlar dahilindedir. Güvenle tarımsal sulamada kullanabilirsiniz.\n(Yapay Zeka Güven Oranı: %{Probability * 100:F0})";
                }
                else
                {
                    return $"⚠️ [SULAMAYA UYGUN DEĞİL]\nSu değerlerinde (Tuzluluk, Klor, Nitrat veya Sodyum) limit aşımı tespit edilmiştir! Doğrudan kullanılması mahsul kalitesini düşürebilir.\n(Yapay Zeka Güven Oranı: %{(1 - Probability) * 100:F0})";
                }
            }
        }
    }
}