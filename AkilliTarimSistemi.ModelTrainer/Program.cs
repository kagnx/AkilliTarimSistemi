using AkilliTarimSistemi.ML;
using System;

namespace AkilliTarimSistemi.ModelTrainer;

internal class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("===== Akıllı Tarım Sistemi - Model Eğitici =====\n");

        try
        {
            Console.WriteLine("1. Ürün Tavsiye Modeli (LightGBM) eğitiliyor...");
            UrunTavsiyeModelBuilder.TrainAndSaveModel();
            Console.WriteLine("   ✓ Ürün tavsiye modeli eğitildi ve kaydedildi.\n");

            Console.WriteLine("2. Verim Tahmini Modeli (LightGBM) eğitiliyor...");
            VerimTahminiModelBuilder.TrainAndSaveModel();
            Console.WriteLine("   ✓ Verim tahmini modeli eğitildi ve kaydedildi.\n");

            Console.WriteLine("3. Gübre Önerisi Modelleri (Azot, Fosfor, Potasyum) eğitiliyor...");
            GubreOnerisiModelBuilder.TrainAndSaveModels();
            Console.WriteLine("   ✓ Gübre önerisi modelleri eğitildi ve kaydedildi.\n");

            Console.WriteLine("===== Tüm modeller başarıyla eğitildi! =====");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"HATA: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }

        Console.WriteLine("\nÇıkmak için bir tuşa basın...");
        Console.ReadKey();
    }
}