using AkilliTarimSistemi.DAL.Context;
using AkilliTarimSistemi.DAL.UnitOfWork;
using AkilliTarimSistemi.IoT;
using AkilliTarimSistemi.ML;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.Services;
using AkilliTarimSistemi.Services.Notification;
using AkilliTarimSistemi.Services.Logging;
using AkilliTarimSistemi.Services.Backup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AkilliTarimSistemi.UI
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // OTOMATIK YEDIKLEME (her baslangicta)
            string dbPath = Path.Combine(Application.StartupPath, "AkilliTarim.db");
            if (File.Exists(dbPath))
            {
                try
                {
                    BackupService.VeritabaniYedekle(dbPath);
                    BackupService.EskiYedekleriTemizle(30); // 30 gun onceki yedekleri temizle
                    LogManager.BilgiYaz("Veritabani otomatik yedeklendi.", "Program");
                }
                catch (Exception ex)
                {
                    LogManager.HataYaz("Otomatik yedekleme hatasi", ex, "Program");
                }
            }

            // MODEL EGITIM TETIKLEYICISI
            string flagFilePath = Path.Combine(Application.StartupPath, "models_trained.flag");

            if (!File.Exists(flagFilePath))
            {
                try
                {
                    string dataKlasoru = Path.Combine(Application.StartupPath, "Data");
                    string mlModelsKlasoru = Path.Combine(Application.StartupPath, "MLModels");

                    if (!Directory.Exists(dataKlasoru)) Directory.CreateDirectory(dataKlasoru);
                    if (!Directory.Exists(mlModelsKlasoru)) Directory.CreateDirectory(mlModelsKlasoru);

                    Console.WriteLine($"Data Klasoru: {dataKlasoru}");
                    Console.WriteLine($"MLModels Klasoru: {mlModelsKlasoru}");

                    string suAnalizCsv = Path.Combine(dataKlasoru, "su_analiz_data.csv");
                    string yaprakAnalizCsv = Path.Combine(dataKlasoru, "yaprak_analiz_data.csv");

                    Console.WriteLine("Urun Tavsiye Modeli egitiliyor...");
                    UrunTavsiyeModelBuilder.TrainAndSaveModel();

                    Console.WriteLine("Gubre Onerisi Modelleri egitiliyor...");
                    GubreOnerisiModelBuilder.TrainAndSaveModels();

                    Console.WriteLine("Verim Tahmini Modeli egitiliyor...");
                    VerimTahminiModelBuilder.TrainAndSaveModel();

                    if (File.Exists(suAnalizCsv))
                    {
                        Console.WriteLine("Su Analiz Modeli egitiliyor...");
                        string suModelZipi = Path.Combine(mlModelsKlasoru, "SuAnalizModel.zip");
                        SuAnalizModelBuilder.TrainAndSaveModel(suAnalizCsv, suModelZipi);
                    }

                    if (File.Exists(yaprakAnalizCsv))
                    {
                        Console.WriteLine("Yaprak Analiz Modeli egitiliyor...");
                        string yaprakModelZipi = Path.Combine(mlModelsKlasoru, "YaprakAnalizModel.zip");
                        YaprakAnalizModelBuilder.TrainAndSaveModel(yaprakAnalizCsv, yaprakModelZipi);
                    }

                    File.Create(flagFilePath).Dispose();
                    LogManager.BilgiYaz("Tum YZ modelleri egitildi.", "Program");
                }
                catch (Exception ex)
                {
                    LogManager.HataYaz("Model egitim hatasi", ex, "Program");
                }
            }

            // DI KAYITLARI
            var services = new ServiceCollection();

            services.AddDbContext<AkilliTarimDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IToprakAnalizServisi, ToprakAnalizServisi>();
            services.AddScoped<IYaprakAnaliziServisi, YaprakAnaliziServisi>();
            services.AddScoped<ISuAnalizServisi, SuAnalizServisi>();
            services.AddScoped<ISuKaynagiServisi, SuKaynagiServisi>();
            services.AddScoped<IUrunTavsiyeServisi, UrunTavsiyeServisi>();
            services.AddScoped<IVerimTahminiServisi, VerimTahminiServisi>();
            services.AddScoped<IGubreOnerisiServisi, GubreOnerisiServisi>();
            services.AddScoped<ITarlaService, TarlaService>();
            services.AddSingleton<ISensorDataProvider, SensorSimulator>();
            services.AddScoped<IIoTSensorService, IoTSensorService>();
            services.AddSingleton<BildirimServisi>();

            services.AddSingleton<AnaForm>(provider => new AnaForm(provider));
            services.AddTransient<ToprakAnalizForm>();
            services.AddTransient<YaprakAnalizForm>();
            services.AddTransient<SuAnalizForm>();
            services.AddTransient<OtomasyonForm>();
            services.AddTransient<RaporlamaForm>();
            services.AddTransient<TarlaForm>();
            services.AddTransient<Hakkinda>();

            ServiceProvider = services.BuildServiceProvider();

            // VERITABANI KONTROLU
            using (var dbScope = ServiceProvider.CreateScope())
            {
                try
                {
                    var context = dbScope.ServiceProvider.GetRequiredService<AkilliTarimDbContext>();

                    // Veritabanini model ile esle - EnsureCreated migration gerektirmez
                    if (!context.Database.CanConnect())
                    {
                        context.Database.EnsureCreated();
                    }
                    else
                    {
                        // Mevcut veritabani varsa migration uygulamayi dene
                        try
                        {
                            context.Database.Migrate();
                        }
                        catch
                        {
                            // Migration hatasi olursa veritabanini sil ve yeniden olustur
                            context.Database.EnsureDeleted();
                            context.Database.EnsureCreated();
                        }
                    }

                    if (!context.SuKaynaklari.Any())
                    {
                        var varsayilanKaynaklar = new List<SuKaynagi>
                        {
                            new SuKaynagi { Ad = "Dere / Akarsu", KaynakTipi = "Yerustu", AktifMi = true, Konum = "Genel" },
                            new SuKaynagi { Ad = "Irmak / Nehir", KaynakTipi = "Yerustu", AktifMi = true, Konum = "Genel" },
                            new SuKaynagi { Ad = "Gol / Golet", KaynakTipi = "Yerustu", AktifMi = true, Konum = "Genel" },
                            new SuKaynagi { Ad = "Sulama Kanali", KaynakTipi = "Yerustu", AktifMi = true, Konum = "Genel" },
                            new SuKaynagi { Ad = "Sebeke Suyu", KaynakTipi = "Sebeke", AktifMi = true, Konum = "Genel" },
                            new SuKaynagi { Ad = "Deniz Suyu", KaynakTipi = "Yerustu", AktifMi = true, Konum = "Genel" },
                            new SuKaynagi { Ad = "Kuyu Suyu (Dogal)", KaynakTipi = "Yeralti", AktifMi = true, Konum = "Genel" },
                            new SuKaynagi { Ad = "Kuyu Suyu (Sondaj)", KaynakTipi = "Yeralti", AktifMi = true, Konum = "Genel" },
                            new SuKaynagi { Ad = "Yagmur Suyu Toplama", KaynakTipi = "Alternatif", AktifMi = true, Konum = "Genel" }
                        };
                        context.SuKaynaklari.AddRange(varsayilanKaynaklar);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message.ToLower();
                    if (!msg.Contains("already exists") && !msg.Contains("sqlite error 1"))
                    {
                        LogManager.HataYaz("Veritabani hatasi", ex, "Program");
                    }
                }
            }

            // GIRIS EKRANI (basit versiyon)
            LogManager.BilgiYaz("Uygulama baslatildi.", "Program");
            var anaForm = ServiceProvider.GetRequiredService<AnaForm>();
            Application.Run(anaForm);
        }
    }
}
