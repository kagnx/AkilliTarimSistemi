using Microsoft.ML;
using AkilliTarimSistemi.ML.Models;
using System.IO;
using System;
using Microsoft.ML.Data;

namespace AkilliTarimSistemi.ML
{
    public static class VerimTahminiModelBuilder
    {
        private static readonly string DataPath = Path.Combine(AppContext.BaseDirectory, "Data", "verim_data.csv");
        private static readonly string ModelPath = Path.Combine(AppContext.BaseDirectory, "MLModels", "verim_tahmini_model.zip");

        public static void TrainAndSaveModel()
        {
            var mlContext = new MLContext(seed: 42);
            var dataView = mlContext.Data.LoadFromTextFile<VerimTahminiData>(DataPath, hasHeader: true, separatorChar: ',');

            // Kategorisel verileri ayrıştırıp, sayısal olanları ölçeklendiriyoruz
            var pipeline = mlContext.Transforms.CopyColumns("Label", nameof(VerimTahminiData.GecmisVerim_kg))
                .Append(mlContext.Transforms.Conversion.ConvertType("ToprakTuruStr", nameof(VerimTahminiData.ToprakTuru), DataKind.String))
                .Append(mlContext.Transforms.Conversion.ConvertType("UrunTipiStr", nameof(VerimTahminiData.UrunTipi), DataKind.String))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("ToprakFeatures", "ToprakTuruStr"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("UrunFeatures", "UrunTipiStr"))
                // Sayısal alanları normalize ediyoruz
                .Append(mlContext.Transforms.Concatenate("NumericFeatures",
                    nameof(VerimTahminiData.pH),
                    nameof(VerimTahminiData.OrganikMadde),
                    nameof(VerimTahminiData.Tuzluluk),
                    nameof(VerimTahminiData.Yagis_mm),
                    nameof(VerimTahminiData.Sicaklik_ort)))
                .Append(mlContext.Transforms.NormalizeMinMax("NormalizedNumeric", "NumericFeatures"))
                // Tüm girdileri (Features) ve durum bayraklarını (Boolean) birleştiriyoruz
                .Append(mlContext.Transforms.Concatenate("Features",
                    "NormalizedNumeric",
                    "ToprakFeatures",
                    "UrunFeatures",
                    nameof(VerimTahminiData.SulamaYapildiMi),
                    nameof(VerimTahminiData.Gubreleme_TamMi)))
                // Gelişmiş Regresyon Eğitmeni
                .Append(mlContext.Regression.Trainers.LightGbm(new Microsoft.ML.Trainers.LightGbm.LightGbmRegressionTrainer.Options
                {
                    NumberOfIterations = 400, // Yoğun ağaç derinliği ile yüksek doğruluk hedefi
                    LearningRate = 0.03f,
                    Seed = 42
                }))
                .Append(mlContext.Transforms.CopyColumns(nameof(VerimTahminiPrediction.PredictedVerim), "Score"));

            var split = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            var model = pipeline.Fit(split.TrainSet);

            Directory.CreateDirectory(Path.GetDirectoryName(ModelPath)!);
            mlContext.Model.Save(model, split.TrainSet.Schema, ModelPath);
        }

        public static ITransformer LoadModel()
        {
            var mlContext = new MLContext();
            return mlContext.Model.Load(ModelPath, out _);
        }
    }
}