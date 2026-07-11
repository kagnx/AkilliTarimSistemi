using AkilliTarimSistemi.Core.Enums;

namespace AkilliTarimSistemi.Core.Entities;

public class SensorVerisi : BaseEntity
{
    public int TarlaId { get; set; }
    public DateTime OkumaZamani { get; set; }
    public double Sicaklik { get; set; }
    public double Nem { get; set; }
    public double ToprakNemi { get; set; }
    public double IsikSiddeti { get; set; }
    public double? pH { get; set; }
    public double? Co2 { get; set; }
    public SulamaDurumu SulamaDurumu { get; set; }

    public virtual Tarla? Tarla { get; set; }
}