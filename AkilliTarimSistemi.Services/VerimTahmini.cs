using AkilliTarimSistemi.Core.DTOs;
using AkilliTarimSistemi.ML;
using AkilliTarimSistemi.ML.Models;
using Microsoft.ML;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services;

public class VerimTahminiServisi : IVerimTahminiServisi
{
    private readonly ITransformer _model;
    private readonly MLContext _mlContext;

    public VerimTahminiServisi()
    {
        _mlContext = new MLContext();
        _model = VerimTahminiModelBuilder.LoadModel();
    }

    public Task<VerimTahminiDto> TahminEtAsync(VerimTahminiDto girdi)
    {
        var input = new VerimTahminiData
        {
            pH = (float)girdi.pH,
            OrganikMadde = (float)girdi.OrganikMadde,
            Tuzluluk = (float)girdi.Tuzluluk,
            ToprakTuru = (float)girdi.ToprakTuru,
            UrunTipi = (float)girdi.UrunTipi,
            Yagis_mm = (float)girdi.Yagis_mm,
            Sicaklik_ort = (float)girdi.Sicaklik_ort,
            SulamaYapildiMi = girdi.SulamaYapildiMi ? 1 : 0,
            Gubreleme_TamMi = girdi.Gubreleme_TamMi ? 1 : 0,
            GecmisVerim_kg = 0
        };

        var predEngine = _mlContext.Model.CreatePredictionEngine<VerimTahminiData, VerimTahminiPrediction>(_model);
        var prediction = predEngine.Predict(input);

        girdi.TahminiVerim = (double)prediction.PredictedVerim;
        return Task.FromResult(girdi);
    }
}