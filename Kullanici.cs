namespace AkilliTarimSistemi.Core.Entities
{
    public class Kullanici : BaseEntity
    {
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Rol { get; set; } = "Kullanici";
    }
}