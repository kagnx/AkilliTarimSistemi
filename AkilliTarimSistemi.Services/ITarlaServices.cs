using AkilliTarimSistemi.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services
{
    public interface ITarlaService
    {
        Task<IEnumerable<Tarla>> GetAllAsync();
        Task AddAsync(Tarla entity);
        // İhtiyacınız olan diğer metot imzalarını (Delete, Update vb.) buraya ekleyebilirsiniz
    }
}