using Microsoft.ML.Data;

namespace AkilliTarimSistemi.ML.Models
{
    public class GubreOnerisiPrediction
    {
        // ML.NET genellikle tahmin sonucunu 'Score' sütununa yazar.
        // Hem 'Score' hem de 'PredictedValue' ile çalışabilmek için her ikisini de tanımlayalım.

        //[ColumnName("Score")]
        //public float TahminEdilenMiktar { get; set; }
        // Bu özelliği ekle
        public float PredictedValue { get; set; }

        // Veya regresyon modeli kullanıyorsan:
        public float Score { get; set; }

        // Eğer modelin regresyon modeli ise 'Score' zaten tahmin edilen değerdir.
        // Hataları kökten çözmek için ismini TahminEdilenMiktar olarak güncelliyoruz.
    }
}