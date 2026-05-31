using AkilliTarimSistemi.ML.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AkilliTarimSistemi.Core.DTOs;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services;

public interface IVerimTahminiServisi
{
    Task<VerimTahminiDto> TahminEtAsync(VerimTahminiDto girdi);
}