using AkilliTarimSistemi.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services
{
    public interface IYaprakAnaliziServisi
    {
        Task<IEnumerable<YaprakAnaliziDto>> GetAllAsync();
        Task<YaprakAnaliziDto?> GetByIdAsync(int id);
        Task AddAsync(YaprakAnaliziDto dto);
        Task UpdateAsync(YaprakAnaliziDto dto);
        Task DeleteAsync(int id);
    }
}