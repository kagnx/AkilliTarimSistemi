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
        var inputData = new VerimTahminiData
        {
            Azot = (float)girdi.Azot,
            Fosfor = (float)girdi.Fosfor,
            Potasyum = (float)girdi.Potasyum,
            pH = (float)girdi.pH,
            OrganikMadde = (float)girdi.OrganikMadde,
            Tuzluluk = (float)girdi.Tuzluluk,
            ToprakTuru = girdi.ToprakTuru.ToString(),
            UrunTipi = girdi.UrunTipi.ToString(),
            Yagis_mm = (float)girdi.Yagis_mm,
            Sicaklik_Ort = (float)girdi.Sicaklik_Ort,
            SulamaYapildiMi = girdi.SulamaYapildiMi,
            Gubreleme_TamMi = girdi.Gubreleme_TamMi,
            GecmisVerim_kg = 0
        };

        var predEngine = _mlContext.Model.CreatePredictionEngine<VerimTahminiData, VerimTahminiPrediction>(_model);
        var prediction = predEngine.Predict(inputData);

        girdi.TahminiVerim = (double)prediction.PredictedVerim;
        girdi.GuvenSkoru = prediction.Score;
        return Task.FromResult(girdi);
    }
}
