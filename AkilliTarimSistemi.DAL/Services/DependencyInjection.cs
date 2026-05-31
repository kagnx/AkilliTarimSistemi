using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AkilliTarimSistemi.DAL.Context;
using AkilliTarimSistemi.DAL.Repositories;
using AkilliTarimSistemi.DAL.UnitOfWork;

namespace AkilliTarimSistemi.DAL.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddDALDependencies(this IServiceCollection services, string connectionString)
    {
        // SADECE AkilliTarimDbContext kullan
        services.AddDbContext<AkilliTarimDbContext>(options =>
            options.UseSqlite(connectionString));

        // Repository'ler
        services.AddScoped<IYaprakAnalizRepository, YaprakAnalizRepository>();
        services.AddScoped<ISuAnalizRepository, SuAnalizRepository>();
        services.AddScoped<ISensorVerisiRepository, SensorVerisiRepository>();
        services.AddScoped<IUrunTavsiyesiRepository, UrunTavsiyesiRepository>();
        services.AddScoped<IGubreOnerisiRepository, GubreOnerisiRepository>();
        services.AddScoped<IVerimTahminiRepository, VerimTahminiRepository>();
        services.AddScoped<ITarlaRepository, TarlaRepository>();
        services.AddScoped<IKullaniciRepository, KullaniciRepository>();

        // DÜZELTİLMİŞ HALİ (tam isim)
        services.AddScoped<IUnitOfWork, AkilliTarimSistemi.DAL.UnitOfWork.UnitOfWork>();

        return services;
    }
}