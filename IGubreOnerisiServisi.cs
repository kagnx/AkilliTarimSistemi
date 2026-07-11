using AkilliTarimSistemi.Core.DTOs;
using AkilliTarimSistemi.Core.Enums;

namespace AkilliTarimSistemi.Services;

public interface IGubreOnerisiServisi
{
    Task<GubreOnerisiDto> OnerAsync(ToprakAnaliziDto analiz, UrunTipi urun);
}