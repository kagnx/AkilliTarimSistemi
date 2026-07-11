using AkilliTarimSistemi.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services;

public interface IToprakAnalizServisi
{
    Task<IEnumerable<ToprakAnaliziDto>> GetAllAsync();
    Task<ToprakAnaliziDto?> GetByIdAsync(int id);
    Task AddAsync(ToprakAnaliziDto analizDto);
    Task UpdateAsync(ToprakAnaliziDto analizDto);
    Task DeleteAsync(int id);
}