using System;
using System.IO;
using AkilliTarimSistemi.ML.Models;
using Microsoft.ML;

namespace AkilliTarimSistemi.ML
{
    public static class SuAnalizModelBuilder
    {
        private static readonly MLContext mlContext = new MLContext();

        // UI veya Trainer projelerinin ortak erişebileceği varsayılan çalışma dizini yolu
        private static string GetDefaultModelPath()
        {
            // Eğer UI projesinden çağrılıyorsa kendi klasöründeki MLModels'a bakar
            return Path.Combine(AppContext.BaseDirectory, "MLModels", "SuAnalizModel.zip");
        }

        public static ITransformer LoadModel(string? customModelPath = null)
        {
            string finalPath = customModelPath ?? GetDefaultModelPath();

            if (!File.Exists(finalPath))
            {
                throw new FileNotFoundException($"Eğitilmiş su analiz modeli bulunamadı! Aranan konum: {finalPath}. Lütfen önce ModelTrainer uygulamasını çalıştırın.");
            }

            return mlContext.Model.Load(finalPath, out _);
        }

        /// <summary>
        /// Python tarafından üretilen 75.000 satırlık gerçek veri setiyle modeli eğitir ve kaydeder.
        /// </summary>
        public static void TrainAndSaveModel(string csvPath, string modelOutputPath)
        {
            if (!File.Exists(csvPath))
                throw new FileNotFoundException($"Eğitim için kaynak CSV dosyası bulunamadı: {csvPath}");

            // Klasör yoksa otomatik oluştur ki "DirectoryNotFoundException" fırlatmasın
            string? directory = Path.GetDirectoryName(modelOutputPath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // 1. Veriyi CSV dosyasından yükle
            IDataView trainData = mlContext.Data.LoadFromTextFile<SuAnaliziData>(csvPath, hasHeader: true, separatorChar: ',');

            // 2. Eğitim İşlem Hattı (Pipeline)
            // NOT: SuAnaliziData sınıfınızda SulamayaUygun alanında [ColumnName("Label")] yoksa, 
            // labelColumnName kısmına doğrudan şuradaki ismi vermelisiniz: labelColumnName: "SulamayaUygun"
            var pipeline = mlContext.Transforms.Concatenate("Features",
                    "pH", "EC", "Sertlik", "Nitrat", "Nitrit", "Sodyum", "Klor")
                .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label"));

            // 3. Modeli Eğit
            var model = pipeline.Fit(trainData);

            // 4. İstenen klasöre kaydet (Burada gönderdiğin UI/bin/Debug/.../MLModels/SuAnalizModel.zip yoluna kaydeder)
            mlContext.Model.Save(model, trainData.Schema, modelOutputPath);
        }
    }
}