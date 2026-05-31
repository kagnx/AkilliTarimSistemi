
namespace AkilliTarimSistemi.Core.Entities;

public class Kullanici : BaseEntity
{
    // BaseEntity'de Id, OlusturmaTarihi zaten var, TEKRAR TANIMLAMA
    public string Ad { get; set; } = string.Empty;
    public string Soyad { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string SifreHash { get; set; } = string.Empty;
    public string Rol { get; set; } = "Ciftci";
    public string? Telefon { get; set; }
    public string? Adres { get; set; }

    public virtual ICollection<Tarla> Tarlalar { get; set; } = new List<Tarla>();
}
//using System.Collections.Generic;

//namespace AkilliTarimSistemi.Core.Entities
//{
//    public class Kullanici : BaseEntity
//    {
//        public string Ad { get; set; } = string.Empty;
//        public string Soyad { get; set; } = string.Empty;
//        public string Email { get; set; } = string.Empty;
//        public string SifreHash { get; set; } = string.Empty;
//        public string Rol { get; set; } = "Ciftci";
//        public string? Telefon { get; set; }
//        public string? Adres { get; set; }
//        public virtual ICollection<Tarla> Tarlalar { get; set; } = new List<Tarla>();
//    }
//}