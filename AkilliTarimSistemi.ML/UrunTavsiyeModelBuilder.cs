using Microsoft.ML;
using AkilliTarimSistemi.ML.Models;
using System;
using System.IO;
using Microsoft.ML.Data;

namespace AkilliTarimSistemi.ML
{
    public static class UrunTavsiyeModelBuilder
    {
        private static readonly string DataPath = Path.Combine(AppContext.BaseDirectory, "Data", "tarim_data.csv");
        private static readonly string ModelPath = Path.Combine(AppContext.BaseDirectory, "MLModels", "urun_tavsiye_model.zip");

        public static void TrainAndSaveModel()
        {
            var mlContext = new MLContext(seed: 42);
            var dataView = mlContext.Data.LoadFromTextFile<UrunTavsiyeData>(DataPath, hasHeader: true, separatorChar: ',');

            var trainTestSplit = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            var trainData = trainTestSplit.TrainSet;

            // Pipeline Akışı
            var pipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(UrunTavsiyeData.UrunTipi))
                // ToprakTuru'nu sayısal büyüklük olarak görmemesi için önce String'e, sonra One-Hot'a çeviriyoruz
                .Append(mlContext.Transforms.Conversion.ConvertType("ToprakTuruStr", nameof(UrunTavsiyeData.ToprakTuru), DataKind.String))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("ToprakTuruFeatures", "ToprakTuruStr"))
                // Sayısal değerleri bir araya getiriyoruz
                .Append(mlContext.Transforms.Concatenate("NumericFeatures",
                    nameof(UrunTavsiyeData.pH),
                    nameof(UrunTavsiyeData.Azot),
                    nameof(UrunTavsiyeData.Fosfor),
                    nameof(UrunTavsiyeData.Potasyum),
                    nameof(UrunTavsiyeData.OrganikMadde),
                    nameof(UrunTavsiyeData.Tuzluluk)))
                // Sayısal uçurumları (Örn: pH=6, Potasyum=250) dengelemek için Normalizasyon ekliyoruz
                .Append(mlContext.Transforms.NormalizeMinMax("NormalizedNumeric", "NumericFeatures"))
                // Tüm özellikleri nihai "Features" sütununda birleştiriyoruz
                .Append(mlContext.Transforms.Concatenate("Features", "NormalizedNumeric", "ToprakTuruFeatures"))
                // Gelişmiş Hiper-Parametreli LightGbm Eğitimcisi
                .Append(mlContext.MulticlassClassification.Trainers.LightGbm(new Microsoft.ML.Trainers.LightGbm.LightGbmMulticlassTrainer.Options
                {
                    NumberOfIterations = 300, // Daha fazla ağaç yapısı ile derin öğrenme
                    LearningRate = 0.05f,     // Dengeli öğrenme katsayısı
                    Seed = 42
                }))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue(nameof(UrunTavsiyePrediction.PredictedLabel), "PredictedLabel"));

            var model = pipeline.Fit(trainData);
            Directory.CreateDirectory(Path.GetDirectoryName(ModelPath)!);
            mlContext.Model.Save(model, trainData.Schema, ModelPath);
        }

        public static ITransformer LoadModel()
        {
            var mlContext = new MLContext();
            return mlContext.Model.Load(ModelPath, out _);
        }
    }
}