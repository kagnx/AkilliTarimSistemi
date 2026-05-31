namespace AkilliTarimSistemi.Core.DTOs
{
    public class TahminSonucDto
    {
        public string TavsiyeEdilenUrun { get; set; } = string.Empty;
        public double VerimTahminiKgDa { get; set; }
        public string GuveSeviyesi { get; set; } = string.Empty;
        public string? GubreOnerisi { get; set; }
        public string[]? DetayliTavsiyeler { get; set; }
    }
}