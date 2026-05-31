using Microsoft.ML;
using AkilliTarimSistemi.ML.Models;
using System.IO;
using System;
using Microsoft.ML.Data;

namespace AkilliTarimSistemi.ML
{
    public static class GubreOnerisiModelBuilder
    {
        private static readonly string DataPath = Path.Combine(AppContext.BaseDirectory, "Data", "gubre_data.csv");
        private static readonly string ModelDir = Path.Combine(AppContext.BaseDirectory, "MLModels");

        public static void TrainAndSaveModels()
        {
            var mlContext = new MLContext(seed: 42);
            var dataView = mlContext.Data.LoadFromTextFile<GubreOnerisiData>(DataPath, hasHeader: true, separatorChar: ',');

            var split = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            var trainSet = split.TrainSet;

            // Ortak Feature Hazırlama Akışı (Kategorisel Dönüşümler ve Normalizasyon)
            var featurePipeline = mlContext.Transforms.Conversion.ConvertType("ToprakTuruStr", nameof(GubreOnerisiData.ToprakTuru), DataKind.String)
                .Append(mlContext.Transforms.Conversion.ConvertType("UrunTipiStr", nameof(GubreOnerisiData.UrunTipi), DataKind.String))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("ToprakFeatures", "ToprakTuruStr"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("UrunFeatures", "UrunTipiStr"))
                .Append(mlContext.Transforms.Concatenate("NumericFeatures",
                    nameof(GubreOnerisiData.pH),
                    nameof(GubreOnerisiData.Azot_ppm),
                    nameof(GubreOnerisiData.Fosfor_ppm),
                    nameof(GubreOnerisiData.Potasyum_ppm),
                    nameof(GubreOnerisiData.OrganikMadde)))
                .Append(mlContext.Transforms.NormalizeMinMax("NormalizedNumeric", "NumericFeatures"))
                .Append(mlContext.Transforms.Concatenate("Features", "NormalizedNumeric", "ToprakFeatures", "UrunFeatures"));

            // LightGbm Ortak Ayarları
            var lgbmOptions = new Microsoft.ML.Trainers.LightGbm.LightGbmRegressionTrainer.Options
            {
                NumberOfIterations = 350,
                LearningRate = 0.04f,
                Seed = 42
            };

            // === 1. Azot Modeli ===
            var azotPipeline = mlContext.Transforms.CopyColumns("Label", nameof(GubreOnerisiData.OnerilenAzot))
                .Append(featurePipeline)
                .Append(mlContext.Regression.Trainers.LightGbm(lgbmOptions))
                .Append(mlContext.Transforms.CopyColumns(nameof(GubreOnerisiPrediction.PredictedValue), "Score"));
            var azotModel = azotPipeline.Fit(trainSet);

            // === 2. Fosfor Modeli ===
            var fosforPipeline = mlContext.Transforms.CopyColumns("Label", nameof(GubreOnerisiData.OnerilenFosfor))
                .Append(featurePipeline)
                .Append(mlContext.Regression.Trainers.LightGbm(lgbmOptions))
                .Append(mlContext.Transforms.CopyColumns(nameof(GubreOnerisiPrediction.PredictedValue), "Score"));
            var fosforModel = fosforPipeline.Fit(trainSet);

            // === 3. Potasyum Modeli ===
            var potasyumPipeline = mlContext.Transforms.CopyColumns("Label", nameof(GubreOnerisiData.OnerilenPotasyum))
                .Append(featurePipeline)
                .Append(mlContext.Regression.Trainers.LightGbm(lgbmOptions))
                .Append(mlContext.Transforms.CopyColumns(nameof(GubreOnerisiPrediction.PredictedValue), "Score"));
            var potasyumModel = potasyumPipeline.Fit(trainSet);

            // Klasör oluştur ve modelleri kaydet
            Directory.CreateDirectory(ModelDir);
            mlContext.Model.Save(azotModel, trainSet.Schema, Path.Combine(ModelDir, "gubre_onerisi_azot_model.zip"));
            mlContext.Model.Save(fosforModel, trainSet.Schema, Path.Combine(ModelDir, "gubre_onerisi_fosfor_model.zip"));
            mlContext.Model.Save(potasyumModel, trainSet.Schema, Path.Combine(ModelDir, "gubre_onerisi_potasyum_model.zip"));
        }

        public static (ITransformer azot, ITransformer fosfor, ITransformer potasyum) LoadModels()
        {
            var mlContext = new MLContext();
            return (
                mlContext.Model.Load(Path.Combine(ModelDir, "gubre_onerisi_azot_model.zip"), out _),
                mlContext.Model.Load(Path.Combine(ModelDir, "gubre_onerisi_fosfor_model.zip"), out _),
                mlContext.Model.Load(Path.Combine(ModelDir, "gubre_onerisi_potasyum_model.zip"), out _)
            );
        }
    }
}