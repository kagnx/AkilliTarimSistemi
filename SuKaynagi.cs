using System;

namespace AkilliTarimSistemi.Core.Entities
{
    public class SuKaynagi
    {
        public int Id { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string Konum { get; set; } = string.Empty;
        public string KaynakTipi { get; set; } = string.Empty; // Yerüstü, Yeraltı vb.
        public bool AktifMi { get; set; } = true;
        public DateTime SonGuncellemeTarihi { get; set; } = DateTime.Now;
    }
}