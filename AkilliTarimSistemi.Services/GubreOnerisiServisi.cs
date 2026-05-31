using AkilliTarimSistemi.Core.DTOs;
using AkilliTarimSistemi.Core.Enums;
using AkilliTarimSistemi.ML;
using AkilliTarimSistemi.ML.Models;
using Microsoft.ML;

namespace AkilliTarimSistemi.Services;

public class GubreOnerisiServisi : IGubreOnerisiServisi
{
    private readonly MLContext _mlContext;
    private readonly ITransformer _azotModel;
    private readonly ITransformer _fosforModel;
    private readonly ITransformer _potasyumModel;

    public GubreOnerisiServisi()
    {
        _mlContext = new MLContext();
        var models = GubreOnerisiModelBuilder.LoadModels();
        _azotModel = models.azot;
        _fosforModel = models.fosfor;
        _potasyumModel = models.potasyum;
    }

    public Task<GubreOnerisiDto> OnerAsync(ToprakAnaliziDto analiz, UrunTipi urun)
    {
        var input = new GubreOnerisiData
        {
            pH = (float)analiz.pH,
            Azot_ppm = (float)analiz.Azot,
            Fosfor_ppm = (float)analiz.Fosfor,
            Potasyum_ppm = (float)analiz.Potasyum,
            OrganikMadde = (float)analiz.OrganikMadde,
            ToprakTuru = (float)analiz.ToprakTipi,
            UrunTipi = (float)urun,
            OnerilenAzot = 0,
            OnerilenFosfor = 0,
            OnerilenPotasyum = 0
        };

        // Tahmin motorları
        var azotEngine = _mlContext.Model.CreatePredictionEngine<GubreOnerisiData, GubreOnerisiPrediction>(_azotModel);
        var fosforEngine = _mlContext.Model.CreatePredictionEngine<GubreOnerisiData, GubreOnerisiPrediction>(_fosforModel);
        var potasyumEngine = _mlContext.Model.CreatePredictionEngine<GubreOnerisiData, GubreOnerisiPrediction>(_potasyumModel);

        var azotPred = azotEngine.Predict(input);
        var fosforPred = fosforEngine.Predict(input);
        var potasyumPred = potasyumEngine.Predict(input);

        var dto = new GubreOnerisiDto
        {
            OnerilenAzot = Math.Round(azotPred.PredictedValue, 1),
            OnerilenFosfor = Math.Round(fosforPred.PredictedValue, 1),
            OnerilenPotasyum = Math.Round(potasyumPred.PredictedValue, 1)
        };

        return Task.FromResult(dto);
    }
}

// Tahmin sonucu için basit sınıf
public class GubreOnerisiPrediction
{
    public float PredictedValue { get; set; }
}