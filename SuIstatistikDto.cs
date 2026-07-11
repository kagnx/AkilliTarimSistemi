namespace AkilliTarimSistemi.Core.DTOs
{
    public class SuIstatistikDto
    {
        public int ToplamAnalizSayisi { get; set; }
        public double OrtalamaSuKalitesi { get; set; }
        public int UygunAnalizSayisi { get; set; }
        public int UygunOlmayanAnalizSayisi { get; set; }
        public double OrtalamaPH { get; set; }
        public double OrtalamaEC { get; set; }
        public double OrtalamaNitrat { get; set; }
        public DateTime SonAnalizTarihi { get; set; }
        public int EnYuksekSkor { get; set; }
        public int EnDusukSkor { get; set; }
        public double UygunlukOrani => ToplamAnalizSayisi > 0 ? (double)UygunAnalizSayisi / ToplamAnalizSayisi * 100 : 0;
    }
}