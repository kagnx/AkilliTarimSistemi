using Microsoft.ML.Data;

namespace AkilliTarimSistemi.ML.Models
{
    public class VerimTahminiPrediction
    {
        [ColumnName("PredictedLabel")]
        public float PredictedVerim { get; set; }

        // HATALI: public float[]? Score { get; set; }
        // DOĞRUSU (Model çıktısı tek bir float'tır):
        [ColumnName("Score")]
        public float Score { get; set; }
    }
}