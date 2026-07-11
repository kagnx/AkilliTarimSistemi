using AkilliTarimSistemi.ML;
using System;
using System.IO;

namespace AkilliTarimSistemi.ModelTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Akili Tarim Sistemi - Model Egitici =====\n");

            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string mlModelsPath = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "..", "AkilliTarimSistemi.ML", "MLModels"));
                string csvDataPath = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "..", "AkilliTarimSistemi.ML", "Data"));

                if (!Directory.Exists(csvDataPath))
                {
                    string uiDataPath = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "..", "AkilliTarimSistemi.UI", "bin", "x64", "Debug", "net10.0-windows10.0.17763.0", "Data"));
                    if (Directory.Exists(uiDataPath))
                    {
                        csvDataPath = uiDataPath;
                    }
                }

                if (!Directory.Exists(mlModelsPath))
                {
                    Directory.CreateDirectory(mlModelsPath);
                    Console.WriteLine($"[INFO] MLModels klasoru olusturuldu: {mlModelsPath}\n");
                }

                if (!Directory.Exists(csvDataPath))
                {
                    Directory.CreateDirectory(csvDataPath);
                    Console.WriteLine($"[INFO] Data klasoru olusturuldu: {csvDataPath}\n");
                }

                Console.WriteLine($"[INFO] Modeller kaydedilecek klasor:\n{mlModelsPath}\n");
                Console.WriteLine($"[INFO] Egitim verileri okunacak klasor:\n{csvDataPath}\n");

                string suCsv = Path.Combine(csvDataPath, "su_analiz_data.csv");
                string yaprakCsv = Path.Combine(csvDataPath, "yaprak_analiz_data.csv");
                string gubreCsv = Path.Combine(csvDataPath, "gubre_data.csv");
                string tarimCsv = Path.Combine(csvDataPath, "tarim_data.csv");
                string verimCsv = Path.Combine(csvDataPath, "verim_data.csv");

                Console.WriteLine("CSV Dosyalari Kontrol Ediliyor:");
                Console.WriteLine($"  su_analiz_data.csv: {(File.Exists(suCsv) ? "Var" : "Yok")}");
                Console.WriteLine($"  yaprak_analiz_data.csv: {(File.Exists(yaprakCsv) ? "Var" : "Yok")}");
                Console.WriteLine($"  gubre_data.csv: {(File.Exists(gubreCsv) ? "Var" : "Yok")}");
                Console.WriteLine($"  tarim_data.csv: {(File.Exists(tarimCsv) ? "Var" : "Yok")}");
                Console.WriteLine($"  verim_data.csv: {(File.Exists(verimCsv) ? "Var" : "Yok")}\n");

                if (File.Exists(tarimCsv))
                {
                    Console.WriteLine("1. Urun Tavsiye Modeli egitiliyor...");
                    string urunModelPath = Path.Combine(mlModelsPath, "UrunTavsiyeModel.zip");
                    UrunTavsiyeModelBuilder.TrainAndSaveModel(urunModelPath);
                    Console.WriteLine("   Urun tavsiye modeli egitildi.\n");
                }
                else
                {
                    Console.WriteLine("1. Urun Tavsiye Modeli atlandi (CSV dosyasi bulunamadi).\n");
                }

                if (File.Exists(verimCsv))
                {
                    Console.WriteLine("2. Verim Tahmini Modeli egitiliyor...");
                    VerimTahminiModelBuilder.TrainAndSaveModel();
                    Console.WriteLine("   Verim tahmini modeli egitildi.\n");
                }
                else
                {
                    Console.WriteLine("2. Verim Tahmini Modeli atlandi (CSV dosyasi bulunamadi).\n");
                }

                if (File.Exists(gubreCsv))
                {
                    Console.WriteLine("3. Gubre Onerisi Modelleri egitiliyor...");
                    GubreOnerisiModelBuilder.TrainAndSaveModels(mlModelsPath);
                    Console.WriteLine("   Gubre onerisi modelleri egitildi.\n");
                }
                else
                {
                    Console.WriteLine("3. Gubre Onerisi Modelleri atlandi (CSV dosyasi bulunamadi).\n");
                }

                if (File.Exists(suCsv))
                {
                    Console.WriteLine("4. Su Analizi Modeli egitiliyor...");
                    string suModelOutput = Path.Combine(mlModelsPath, "SuAnalizModel.zip");
                    SuAnalizModelBuilder.TrainAndSaveModel(suCsv, suModelOutput);
                    Console.WriteLine("   Su analizi modeli egitildi.\n");
                }
                else
                {
                    Console.WriteLine($"4. Su Analizi Modeli atlandi (CSV bulunamadi: {suCsv})\n");
                }

                if (File.Exists(yaprakCsv))
                {
                    Console.WriteLine("5. Yaprak Analizi Modeli egitiliyor...");
                    string yaprakModelOutput = Path.Combine(mlModelsPath, "YaprakAnalizModel.zip");
                    YaprakAnalizModelBuilder.TrainAndSaveModel(yaprakCsv, yaprakModelOutput);
                    Console.WriteLine("   Yaprak analizi modeli egitildi.\n");
                }
                else
                {
                    Console.WriteLine($"5. Yaprak Analizi Modeli atlandi (CSV bulunamadi: {yaprakCsv})\n");
                }

                Console.WriteLine("===== Model egitim sureci tamamlandi! =====");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("\nCikmak icin bir tusa basin...");
            Console.ReadKey();
        }
    }
}
