using AkilliTarimSistemi.DAL.Context;
using AkilliTarimSistemi.DAL.UnitOfWork;
using AkilliTarimSistemi.IoT;
using AkilliTarimSistemi.Services;
using AkilliTarimSistemi.ML;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows.Forms;

namespace AkilliTarimSistemi.UI
{
    internal static class Program
    {
        // ServiceProvider mülkünü statik olarak tutuyoruz, AnaForm buradan güvenle okuyacak
        public static IServiceProvider ServiceProvider { get; private set; } = null!;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /////////////// YAPAY ZEKÂ MODEL EĞİTİM TETİKLEYİCİSİ ///////////////
            try
            {
                //  .zip dosyalarını yüksek doğruluklu yeni pipeline ile sıfırdan üretiyoruz: bir kez oluştur sonra yorum satırı yap 
                //UrunTavsiyeModelBuilder.TrainAndSaveModel();
                //GubreOnerisiModelBuilder.TrainAndSaveModels();
                //VerimTahminiModelBuilder.TrainAndSaveModel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yapay Zekâ modelleri eğitilirken bir durum oluştu:\n{ex.Message}\n\nEğer CSV dosyalarınız 'bin\\Debug\\net10.0-windows\\Data' klasöründe yoksa modeller üretilemeyebilir.",
                    "Yapay Zekâ Altyapısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            /////////////////////////////////////////////////////////////////////

            var services = new ServiceCollection();

            // 1. VERİTABANI BAĞLANTISI (SQLite)
            var dbPath = Path.Combine(Application.StartupPath, "AkilliTarim.db");
            var connectionString = $"Data Source={dbPath}";
            services.AddDbContext<AkilliTarimDbContext>(options =>
                options.UseSqlite(connectionString));

            // 2. UNIT OF WORK
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // 3. İŞ MANTIĞI SERVİSLERİ
            services.AddScoped<IToprakAnalizServisi, ToprakAnalizServisi>();
            services.AddScoped<IYaprakAnaliziServisi, YaprakAnaliziServisi>();
            services.AddScoped<ISuAnalizServisi, SuAnalizServisi>();
            services.AddScoped<IUrunTavsiyeServisi, UrunTavsiyeServisi>();
            services.AddScoped<IVerimTahminiServisi, VerimTahminiServisi>();
            services.AddScoped<IGubreOnerisiServisi, GubreOnerisiServisi>();
            services.AddScoped<ITarlaService, TarlaService>(); // Tarlaları getiren hayati servisimiz

            // 4. IOT SERVİSLERİ
            services.AddSingleton<ISensorDataProvider, SensorSimulator>();
            services.AddScoped<IIoTSensorService, IoTSensorService>();

            // 5. KULLANICI ARAYÜZÜ (FORMLAR)
            // 🚀 DÜZELTİLDİ: AnaForm ömrü boyunca tek olacağı için Singleton yapıldı
            services.AddSingleton<AnaForm>(provider => new AnaForm(provider));

            // Alt formlar her tıklandığında yeniden üretileceği için Transient kalması tamamen doğru.
            services.AddTransient<ToprakAnalizForm>();
            services.AddTransient<YaprakAnalizForm>();
            services.AddTransient<SuAnalizForm>();
            services.AddTransient<TahminForm>();
            services.AddTransient<OtomasyonForm>();
            services.AddTransient<RaporlamaForm>();
            services.AddTransient<TarlaForm>();

            // Servis sağlayıcıyı inşa et
            ServiceProvider = services.BuildServiceProvider();

            // 6. GÜVENLİ VERİTABANI VE MIGRATION KONTROLÜ
            using (var dbScope = ServiceProvider.CreateScope())
            {
                try
                {
                    var context = dbScope.ServiceProvider.GetRequiredService<AkilliTarimDbContext>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message.ToLower();
                    if (errorMsg.Contains("already exists") || errorMsg.Contains("zaten var") || errorMsg.Contains("sqlite error 1"))
                    {
                        // Sessizce devam et
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Veritabanı kontrol edilirken bir durum oluştu (Sistem çalışmaya devam ediyor):\n\n{ex.Message}",
                            "Veritabanı Durumu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }

            // 7. UYGULAMAYI BAŞLAT
            var anaForm = ServiceProvider.GetRequiredService<AnaForm>();
            Application.Run(anaForm);
        }
    }
}