using System.Threading.Tasks;
using AkilliTarimSistemi.Core.DTOs;

namespace AkilliTarimSistemi.Services;

public interface IUrunTavsiyeServisi
{
    // Hem giriş hem çıkış için aynı DTO'yu kullanmak tutarlılık sağlar
    Task<UrunTavsiyesiDto> TavsiyeEtAsync(UrunTavsiyesiDto analiz);
}