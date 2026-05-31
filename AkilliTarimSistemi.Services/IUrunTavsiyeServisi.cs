using AkilliTarimSistemi.Core.DTOs;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services;

public interface IUrunTavsiyeServisi
{
    Task<UrunTavsiyesiDto> TavsiyeEtAsync(ToprakAnaliziDto analiz);
}