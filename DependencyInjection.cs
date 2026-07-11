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
        services.AddDbContext<AkilliTarimDbContext>(options =>
            options.UseSqlite(connectionString));

        // Repository'ler
        services.AddScoped<IToprakAnalizRepository, ToprakAnalizRepository>();
        services.AddScoped<IYaprakAnalizRepository, YaprakAnalizRepository>();
        services.AddScoped<ISuAnalizRepository, SuAnalizRepository>();
        services.AddScoped<ISensorVerisiRepository, SensorVerisiRepository>();
        services.AddScoped<IUrunTavsiyesiRepository, UrunTavsiyesiRepository>();
        services.AddScoped<IGubreOnerisiRepository, GubreOnerisiRepository>();
        services.AddScoped<IVerimTahminiRepository, VerimTahminiRepository>();
        services.AddScoped<ITarlaRepository, TarlaRepository>();
        services.AddScoped<IKullaniciRepository, KullaniciRepository>();

        services.AddScoped<IUnitOfWork, AkilliTarimSistemi.DAL.UnitOfWork.UnitOfWork>();

        return services;
    }
}
