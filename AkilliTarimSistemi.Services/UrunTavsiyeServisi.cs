using AkilliTarimSistemi.Core.DTOs;
using AkilliTarimSistemi.Core.Enums;
using AkilliTarimSistemi.ML;
using AkilliTarimSistemi.ML.Models;
using Microsoft.ML;
using System;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services;

public class UrunTavsiyeServisi : IUrunTavsiyeServisi
{
    private readonly ITransformer _model;
    private readonly MLContext _mlContext;

    public UrunTavsiyeServisi()
    {
        _mlContext = new MLContext();
        _model = UrunTavsiyeModelBuilder.LoadModel();
    }

    public Task<UrunTavsiyesiDto> TavsiyeEtAsync(ToprakAnaliziDto analiz)
    {
        // Girdi verisini ML modelinin beklediği formata dönüştür
        var input = new UrunTavsiyeData
        {
            pH = (float)analiz.pH,
            Azot = (float)analiz.Azot,
            Fosfor = (float)analiz.Fosfor,
            Potasyum = (float)analiz.Potasyum,
            OrganikMadde = (float)analiz.OrganikMadde,
            Tuzluluk = (float)analiz.Tuzluluk,
            ToprakTuru = (float)analiz.ToprakTipi,
            UrunTipi = 0 // placeholder
        };

        // Tahmin motoru oluştur
        var predictionEngine = _mlContext.Model.CreatePredictionEngine<UrunTavsiyeData, UrunTavsiyePrediction>(_model);
        var prediction = predictionEngine.Predict(input);

        // Tahmin edilen label (float) -> enum değerine çevir
        int predictedUrunTipi = (int)Math.Round(prediction.PredictedLabel);

        // Enum'da tanımlı değilse varsayılan (Buğday) ata
        if (!Enum.IsDefined(typeof(UrunTipi), predictedUrunTipi))
            predictedUrunTipi = 1001; // Buğday

        // Güven skoru (opsiyonel) – Score'dan maksimum olasılık
        float confidence = prediction.Score?.Max() ?? 0f;

        var dto = new UrunTavsiyesiDto
        {
            TarlaId = analiz.TarlaId,
            TavsiyeTarihi = DateTime.Now,
            TavsiyeEdilenUrun = (UrunTipi)predictedUrunTipi,
            GuvenSkoru = confidence * 100,
            Gerekce = "Toprak analizine göre ML modeli tarafından önerilmiştir.",
            UygulandiMi = false
        };

        return Task.FromResult(dto);
    }
}