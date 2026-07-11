using AkilliTarimSistemi.Core.DTOs;
using AkilliTarimSistemi.Core.Enums;
using AkilliTarimSistemi.ML;
using AkilliTarimSistemi.ML.Models;
using Microsoft.ML;
using System;
using System.Threading.Tasks;

namespace AkilliTarimSistemi.Services
{
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
                ToprakTuru = analiz.ToprakTipi.ToString(),
                UrunTipi = urun.ToString(),
                Tuzluluk = analiz.Tuzluluk,
                GecmisVerim_kg = 350.0f,
                OnerilenAzot = 0,
                OnerilenFosfor = 0,
                OnerilenPotasyum = 0
            };

            var azotEngine = _mlContext.Model.CreatePredictionEngine<GubreOnerisiData, GubreOnerisiPrediction>(_azotModel);
            var fosforEngine = _mlContext.Model.CreatePredictionEngine<GubreOnerisiData, GubreOnerisiPrediction>(_fosforModel);
            var potasyumEngine = _mlContext.Model.CreatePredictionEngine<GubreOnerisiData, GubreOnerisiPrediction>(_potasyumModel);

            var azotPred = azotEngine.Predict(input);
            var fosforPred = fosforEngine.Predict(input);
            var potasyumPred = potasyumEngine.Predict(input);

            var dto = new GubreOnerisiDto
            {
                OnerilenAzot = (double)Math.Round(azotPred.PredictedValue, 1),
                OnerilenFosfor = (double)Math.Round(fosforPred.PredictedValue, 1),
                OnerilenPotasyum = (double)Math.Round(potasyumPred.PredictedValue, 1),
                HedefUrun = urun,
                OneriTarihi = DateTime.Now
            };

            return Task.FromResult(dto);
        }
    }
}
