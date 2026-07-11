using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services
{
    public class TarlaService : ITarlaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TarlaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Tarla>> GetAllAsync()
        {
            return await _unitOfWork.Tarlalar.GetAllAsync();
        }

        public async Task<Tarla?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Tarlalar.GetByIdAsync(id);
        }

        public async Task AddAsync(Tarla entity)
        {
            await _unitOfWork.Tarlalar.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(Tarla entity)
        {
            _unitOfWork.Tarlalar.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tarla = await _unitOfWork.Tarlalar.GetByIdAsync(id);
            if (tarla != null)
            {
                _unitOfWork.Tarlalar.Delete(tarla);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
