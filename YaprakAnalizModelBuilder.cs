using System;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using AkilliTarimSistemi.ML.Models;

namespace AkilliTarimSistemi.ML
{
    public static class YaprakAnalizModelBuilder
    {
        private static readonly MLContext mlContext = new MLContext();

        public static ITransformer? LoadModel(string? customModelPath = null)
        {
            string defaultPath = Path.Combine(AppContext.BaseDirectory, "MLModels", "YaprakAnalizModel.zip");
            string finalPath = customModelPath ?? defaultPath;

            if (!File.Exists(finalPath))
                return null;

            return mlContext.Model.Load(finalPath, out _);
        }

        public static void TrainAndSaveModel(string csvPath, string modelOutputPath)
        {
            if (!File.Exists(csvPath))
                throw new FileNotFoundException($"Egitim icin kaynak CSV dosyasi bulunamadi: {csvPath}");

            Console.WriteLine($"Yaprak Analiz Modeli egitiliyor...");
            Console.WriteLine($"CSV Dosyasi: {csvPath}");

            string? directory = Path.GetDirectoryName(modelOutputPath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string tempCsvPath = Path.GetTempFileName() + ".csv";
            using (var reader = new StreamReader(csvPath))
            using (var writer = new StreamWriter(tempCsvPath, false, new System.Text.UTF8Encoding(false)))
            {
                string? line;
                bool isFirstLine = true;
                while ((line = reader.ReadLine()) != null)
                {
                    if (isFirstLine)
                    {
                        if (line.StartsWith("\uFEFF"))
                            line = line.Substring(1);
                        Console.WriteLine($"Baslik satiri: {line}");
                        isFirstLine = false;
                    }
                    writer.WriteLine(line);
                }
            }

            var dataView = mlContext.Data.LoadFromTextFile<YaprakAnaliziData>(
                path: tempCsvPath,
                hasHeader: true,
                separatorChar: ',');

            int rowCount = 0;
            using (var cursor = dataView.GetRowCursor(dataView.Schema))
            {
                while (cursor.MoveNext()) rowCount++;
            }
            Console.WriteLine($"Veri yuklendi. Satir sayisi: {rowCount:N0}");

            Console.WriteLine("Veri Shemasi (Sutunlar):");
            foreach (var column in dataView.Schema)
            {
                Console.WriteLine($"  {column.Name} : {column.Type}");
            }

            var pipeline =
                mlContext.Transforms.Conversion.MapValueToKey("Label")
                .Append(mlContext.Transforms.Concatenate(
                    "Features",
                    nameof(YaprakAnaliziData.AzotYuzde),
                    nameof(YaprakAnaliziData.FosforYuzde),
                    nameof(YaprakAnaliziData.PotasyumYuzde),
                    nameof(YaprakAnaliziData.DemirPpm),
                    nameof(YaprakAnaliziData.CinkoPpm),
                    nameof(YaprakAnaliziData.ManganPpm),
                    nameof(YaprakAnaliziData.BakirPpm)))
                .Append(
                    mlContext.MulticlassClassification.Trainers
                        .SdcaMaximumEntropy(
                            labelColumnName: "Label",
                            featureColumnName: "Features"))
                .Append(
                    mlContext.Transforms.Conversion
                        .MapKeyToValue("PredictedLabel"));

            Console.WriteLine("Model egitiliyor...");
            var model = pipeline.Fit(dataView);

            var predictions = model.Transform(dataView);
            var metrics = mlContext.MulticlassClassification.Evaluate(predictions, labelColumnName: "Label");

            Console.WriteLine($"Model Performansi:");
            Console.WriteLine($"  Makro Dogruluk: {metrics.MacroAccuracy:P2}");
            Console.WriteLine($"  Mikro Dogruluk: {metrics.MicroAccuracy:P2}");
            Console.WriteLine($"  Log Loss: {metrics.LogLoss:F4}");

            mlContext.Model.Save(model, dataView.Schema, modelOutputPath);
            Console.WriteLine($"Model basariyla kaydedildi: {modelOutputPath}");

            try { File.Delete(tempCsvPath); } catch { }
        }
    }
}
