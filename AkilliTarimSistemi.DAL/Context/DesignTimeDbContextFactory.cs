using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AkilliTarimSistemi.DAL.Context;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AkilliTarimDbContext>
{
    public AkilliTarimDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AkilliTarimDbContext>();
        optionsBuilder.UseSqlite("Data Source=AkilliTarim.db");
        return new AkilliTarimDbContext(optionsBuilder.Options);
    }
}