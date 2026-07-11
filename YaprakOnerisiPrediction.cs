using Microsoft.ML.Data;

namespace AkilliTarimSistemi.ML.Models
{
    public class YaprakOnerisiPrediction
    {
        [ColumnName("PredictedLabel")]
        public string TespitEdilenEksiklik { get; set; } = string.Empty;

        public float[]? Score { get; set; }

        public string MudahaleOnerisi
        {
            get
            {
                return TespitEdilenEksiklik switch
                {
                    "AZOT EKSİKLİĞİ" => "Dekara 5kg Üre uygulaması önerilir.",
                    "DEMİR EKSİKLİĞİ" => "%0.5'lik şelatlı demir yaprak gübresi uygulayın.",
                    "ÇİNKO EKSİKLİĞİ" => "200cc/100lt suya çinko sülfat ekleyerek püskürtün.",
                    "FOSFOR EKSİKLİĞİ" => "Triple Super Phosphate (TSP) gübresi ile taban gübrelemesi yapın.",
                    "POTASYUM EKSİKLİĞİ" => "Potasyum Sülfat (K2SO4) uygulaması önerilir.",
                    "MANGAN EKSİKLİĞİ" => "Mangan Sülfat yaprak gübresi uygulayın.",
                    "BAKIR EKSİKLİĞİ" => "Bakır Sülfat içeren yaprak gübresi kullanın.",
                    "NORMAL" => "Bitki besin elementleri ideal seviyede. Mevcut gübreleme programına devam edin.",
                    _ => "Besin dengesini kontrol edin. İz element içerikli yaprak gübresi değerlendirilebilir."
                };
            }
        }
    }
}
