using System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.LightGbm;

namespace AkilliTarimSistemi.ML
{
    public static class VerimTahminiModelBuilder
    {
        private static readonly string ModelFileName = "verim_tahmini_model.zip";
        private static readonly string DataPath = Path.Combine(AppContext.BaseDirectory, "Data", "verim_data.csv");
        private static readonly string ModelPath = Path.Combine(AppContext.BaseDirectory, "MLModels", ModelFileName);

        public static void TrainAndSaveModel()
        {
            var mlContext = new MLContext(seed: 42);
            var dataView = mlContext.Data.LoadFromTextFile<VerimTahminiData>(DataPath, hasHeader: true, separatorChar: ',');

            // Pipeline'ı TEK BİR YERDE tanımlıyoruz
            var pipeline = mlContext.Transforms.CopyColumns("Label", nameof(VerimTahminiData.GecmisVerim_kg))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("ToprakFeatures", nameof(VerimTahminiData.ToprakTuru)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("UrunFeatures", nameof(VerimTahminiData.UrunTipi)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("SulamaFeatures", nameof(VerimTahminiData.SulamaYapildiMi)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("GubreFeatures", nameof(VerimTahminiData.Gubreleme_TamMi)))
                .Append(mlContext.Transforms.Concatenate("NumericFeatures",
                    nameof(VerimTahminiData.Azot), nameof(VerimTahminiData.Fosfor), nameof(VerimTahminiData.Potasyum),
                    nameof(VerimTahminiData.pH), nameof(VerimTahminiData.OrganikMadde), nameof(VerimTahminiData.Tuzluluk),
                    nameof(VerimTahminiData.Yagis_mm), nameof(VerimTahminiData.Sicaklik_Ort)))
                .Append(mlContext.Transforms.NormalizeMinMax("NormalizedNumeric", "NumericFeatures"))
                .Append(mlContext.Transforms.Concatenate("Features",
                    "NormalizedNumeric", "ToprakFeatures", "UrunFeatures", "SulamaFeatures", "GubreFeatures"))

                // Eğiticiyi buraya ekliyoruz
                .Append(mlContext.Regression.Trainers.LightGbm(labelColumnName: "Label", featureColumnName: "Features"));

            var split = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            var model = pipeline.Fit(split.TrainSet);

            Directory.CreateDirectory(Path.GetDirectoryName(ModelPath)!);
            mlContext.Model.Save(model, split.TrainSet.Schema, ModelPath);
            Console.WriteLine($"✓ Model başarıyla kaydedildi: {ModelPath}");
        }

        public static ITransformer LoadModel()
        {
            var mlContext = new MLContext();
            if (!File.Exists(ModelPath))
                throw new FileNotFoundException($"Model bulunamadı! Yol: {ModelPath}");

            return mlContext.Model.Load(ModelPath, out _);
        }
    }
}