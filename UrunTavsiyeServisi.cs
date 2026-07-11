using AkilliTarimSistemi.Core.DTOs;
using AkilliTarimSistemi.ML;
using AkilliTarimSistemi.ML.Models;
using Microsoft.ML;
using System;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services;

public class UrunTavsiyeServisi : IUrunTavsiyeServisi
{
    private readonly MLContext _mlContext = new MLContext();
    private readonly ITransformer _model = UrunTavsiyeModelBuilder.LoadModel();

    public Task<UrunTavsiyesiDto> TavsiyeEtAsync(UrunTavsiyesiDto analiz)
    {
        var input = new UrunTavsiyeData
        {
            Azot_ppm = (float)analiz.Azot,
            Fosfor_ppm = (float)analiz.Fosfor,
            Potasyum_ppm = (float)analiz.Potasyum,
            pH = (float)analiz.PH,
            OrganikMadde = (float)analiz.OrganikMadde,
            Tuzluluk = (float)analiz.Tuzluluk,
            ToprakTuru = analiz.ToprakTuru ?? "Bilinmiyor"
        };

        var predictionEngine = _mlContext.Model.CreatePredictionEngine<UrunTavsiyeData, UrunTavsiyePrediction>(_model);
        var result = predictionEngine.Predict(input);

        analiz.TahminEdilenUrun = result.PredictedLabel;

        return Task.FromResult(analiz);
    }
}
