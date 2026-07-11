using AkilliTarimSistemi.Core.DTOs;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services
{
    public class ToprakAnalizServisi : IToprakAnalizServisi
    {
        private readonly IUnitOfWork _unitOfWork;

        public ToprakAnalizServisi(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ToprakAnaliziDto>> GetAllAsync()
        {
            var analizler = await _unitOfWork.ToprakAnalizler.GetAllAsync();
            return analizler.Select(a => new ToprakAnaliziDto
            {
                Id = a.Id,
                TarlaId = a.TarlaId ?? 0,
                TarlaAdi = a.Tarla?.TarlaAdi ?? "",
                AnalizTarihi = a.Tarih,
                ToprakTipi = a.ToprakTipi,
                UrunTipi = a.UrunTipi,
                pH = a.pH,
                OrganikMadde = a.OrganikMadde,
                Tuzluluk = (float)a.Tuzluluk,
                Azot = a.Azot,
                Fosfor = a.Fosfor,
                Potasyum = a.Potasyum,
                KayitTarihi = a.OlusturmaTarihi
            }).ToList();
        }

        public async Task<ToprakAnaliziDto?> GetByIdAsync(int id)
        {
            var a = await _unitOfWork.ToprakAnalizler.GetByIdAsync(id);
            if (a == null) return null;

            return new ToprakAnaliziDto
            {
                Id = a.Id,
                TarlaId = a.TarlaId ?? 0,
                TarlaAdi = a.Tarla?.TarlaAdi ?? "",
                AnalizTarihi = a.Tarih,
                ToprakTipi = a.ToprakTipi,
                UrunTipi = a.UrunTipi,
                pH = a.pH,
                OrganikMadde = a.OrganikMadde,
                Tuzluluk = (float)a.Tuzluluk,
                Azot = a.Azot,
                Fosfor = a.Fosfor,
                Potasyum = a.Potasyum,
                KayitTarihi = a.OlusturmaTarihi
            };
        }

        public async Task AddAsync(ToprakAnaliziDto dto)
        {
            var entity = new ToprakAnalizi
            {
                TarlaId = dto.TarlaId > 0 ? dto.TarlaId : null,
                Tarih = dto.AnalizTarihi,
                UrunTipi = dto.UrunTipi,
                ToprakTipi = dto.ToprakTipi,
                pH = dto.pH,
                Azot = dto.Azot,
                Fosfor = dto.Fosfor,
                Potasyum = dto.Potasyum,
                OrganikMadde = dto.OrganikMadde,
                Tuzluluk = dto.Tuzluluk
            };
            await _unitOfWork.ToprakAnalizler.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(ToprakAnaliziDto dto)
        {
            var entity = await _unitOfWork.ToprakAnalizler.GetByIdAsync(dto.Id);
            if (entity == null) throw new Exception("Analiz bulunamadı");

            entity.TarlaId = dto.TarlaId > 0 ? dto.TarlaId : null;
            entity.Tarih = dto.AnalizTarihi;
            entity.UrunTipi = dto.UrunTipi;
            entity.ToprakTipi = dto.ToprakTipi;
            entity.pH = dto.pH;
            entity.Azot = dto.Azot;
            entity.Fosfor = dto.Fosfor;
            entity.Potasyum = dto.Potasyum;
            entity.OrganikMadde = dto.OrganikMadde;
            entity.Tuzluluk = dto.Tuzluluk;

            _unitOfWork.ToprakAnalizler.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.ToprakAnalizler.GetByIdAsync(id);
            if (entity != null)
            {
                _unitOfWork.ToprakAnalizler.Delete(entity);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
