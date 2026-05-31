using System;

namespace AkilliTarimSistemi.Core.DTOs
{
    public class RaporFiltreDto
    {
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public int? AraziParseliId { get; set; }
        public string? RaporTipi { get; set; } // "Toprak", "Verim", "Sensör"
    }
}