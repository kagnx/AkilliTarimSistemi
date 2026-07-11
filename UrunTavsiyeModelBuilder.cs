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
        private static readonly string DefaultModelPath = Path.Combine(AppContext.BaseDirectory, "MLModels", "UrunTavsiyeModel.zip");

        public static void TrainAndSaveModel(string? outputModelPath = null)
        {
            string finalPath = string.IsNullOrEmpty(outputModelPath) ? DefaultModelPath : outputModelPath;

            var mlContext = new MLContext(seed: 42);
            var dataView = mlContext.Data.LoadFromTextFile<UrunTavsiyeData>(DataPath, hasHeader: true, separatorChar: ',');

            var trainTestSplit = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            var trainData = trainTestSplit.TrainSet;

            var pipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(UrunTavsiyeData.UrunTipi))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("ToprakTuruFeatures", nameof(UrunTavsiyeData.ToprakTuru)))

                .Append(mlContext.Transforms.Concatenate("NumericFeatures",
                    nameof(UrunTavsiyeData.pH),
                    nameof(UrunTavsiyeData.Azot_ppm),
                    nameof(UrunTavsiyeData.Fosfor_ppm),
                    nameof(UrunTavsiyeData.Potasyum_ppm),
                    nameof(UrunTavsiyeData.OrganikMadde),
                    nameof(UrunTavsiyeData.Tuzluluk)))

                .Append(mlContext.Transforms.NormalizeMinMax("NormalizedNumeric", "NumericFeatures"))
                .Append(mlContext.Transforms.Concatenate("Features", "NormalizedNumeric", "ToprakTuruFeatures"))

                .Append(mlContext.MulticlassClassification.Trainers.LightGbm(new Microsoft.ML.Trainers.LightGbm.LightGbmMulticlassTrainer.Options
                {
                    NumberOfIterations = 300,
                    LearningRate = 0.05f,
                    LabelColumnName = "Label",
                    FeatureColumnName = "Features",
                    Seed = 42
                }))
                // DÜZELTME: Tahmin eşlemesi ML.NET standart algoritma çıktısı olan "PredictedLabel" kolonuna bağlandı.
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel", "PredictedLabel"));

            Console.WriteLine("Ürün Tavsiye Modeli (LightGBM) eğitiliyor, lütfen bekleyin...");
            var model = pipeline.Fit(trainData);

            Directory.CreateDirectory(Path.GetDirectoryName(finalPath)!);
            mlContext.Model.Save(model, trainData.Schema, finalPath);
            Console.WriteLine($"🎉 Ürün tavsiye modeli başarıyla kaydedildi: {finalPath}");
        }

        public static ITransformer LoadModel()
        {
            var mlContext = new MLContext();
            return mlContext.Model.Load(DefaultModelPath, out _);
        }
    }
}