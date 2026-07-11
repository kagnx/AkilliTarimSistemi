using AkilliTarimSistemi.Core.Enums;
using System.Collections.Generic;

namespace AkilliTarimSistemi.Core.Entities;

public class Tarla : BaseEntity  // BaseEntity'den türemeli
{
    public string TarlaAdi { get; set; } = string.Empty;
    public double AlanDekar { get; set; }
    public string Konum { get; set; } = string.Empty;
    public ToprakTipi ToprakTipi { get; set; }
    public int? KullaniciId { get; set; }

    // İklim/topoğrafya alanları (isteğe bağlı)
    public double? OrtalamaYagis { get; set; }
    public double? OrtalamaSicaklik { get; set; }

    public virtual Kullanici? Kullanici { get; set; }
    public virtual ICollection<ToprakAnalizi> ToprakAnalizleri { get; set; } = new List<ToprakAnalizi>();
    public virtual ICollection<YaprakAnalizi> YaprakAnalizleri { get; set; } = new List<YaprakAnalizi>();

    // 👇 İŞTE DÜZELTİLEN SATIR BURASI (SuAnalizi -> SuAnaliz yapıldı)
    public virtual ICollection<SuAnaliz> SuAnalizleri { get; set; } = new List<SuAnaliz>();

    public virtual ICollection<SensorVerisi> SensorVerileri { get; set; } = new List<SensorVerisi>();
}
