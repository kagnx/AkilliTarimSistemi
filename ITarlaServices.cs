using AkilliTarimSistemi.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services
{
    public interface ITarlaService
    {
        Task<IEnumerable<Tarla>> GetAllAsync();
        Task<Tarla?> GetByIdAsync(int id);
        Task AddAsync(Tarla entity);
        Task UpdateAsync(Tarla entity);
        Task DeleteAsync(int id);
    }
}
