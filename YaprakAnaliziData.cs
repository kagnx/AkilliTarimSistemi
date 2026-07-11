using Microsoft.ML.Data;

namespace AkilliTarimSistemi.ML.Models
{
    public class YaprakAnaliziData
    {
        [LoadColumn(0)]
        public float AzotYuzde { get; set; }

        [LoadColumn(1)]
        public float FosforYuzde { get; set; }

        [LoadColumn(2)]
        public float PotasyumYuzde { get; set; }

        [LoadColumn(3)]
        public float DemirPpm { get; set; }

        [LoadColumn(4)]
        public float CinkoPpm { get; set; }

        [LoadColumn(5)]
        public float ManganPpm { get; set; }

        [LoadColumn(6)]
        public float BakirPpm { get; set; }

        [LoadColumn(7)]
        [ColumnName("Label")]
        public string GozlenenEksiklik { get; set; } = string.Empty;
    }
}
