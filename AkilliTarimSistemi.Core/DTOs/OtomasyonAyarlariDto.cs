namespace AkilliTarimSistemi.Core.DTOs
{
    public class OtomasyonAyarlariDto
    {
        public int AraziParseliId { get; set; }
        public double ToprakNemiEsik { get; set; } = 30.0;  // % altında sulama başlasın
        public double SicaklikEsik { get; set; } = 35.0;    // °C üstü uyarı
        public bool OtomatikSulamaAktif { get; set; } = false;
        public int SulamaSuresiSaniye { get; set; } = 60;
    }
}