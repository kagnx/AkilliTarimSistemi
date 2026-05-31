using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.UnitOfWork; // UnitOfWork ya da Repository yapın hangisiyse
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services
{
    public class TarlaService : ITarlaService
    {
        private readonly IUnitOfWork _unitOfWork; // Veya IGenericRepository<Tarla>

        // Constructor üzerinden veri katmanını enjekte ediyoruz
        public TarlaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Tarla>> GetAllAsync()
        {
            // Kendi mimarine göre tarlaları çeken kodu yaz:
            return await _unitOfWork.Tarlalar.GetAllAsync();
        }

        public async Task AddAsync(Tarla entity)
        {
            await _unitOfWork.Tarlalar.AddAsync(entity);
            await _unitOfWork.CompleteAsync(); // Değişiklikleri kaydet
        }
    }
}