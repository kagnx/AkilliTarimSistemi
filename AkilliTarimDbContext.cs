using Microsoft.EntityFrameworkCore;
using AkilliTarimSistemi.Core.Entities;

namespace AkilliTarimSistemi.DAL.Context
{
    public class AkilliTarimDbContext : DbContext
    {
        public AkilliTarimDbContext() { }

        public AkilliTarimDbContext(DbContextOptions<AkilliTarimDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=AkilliTarim.db");
            }
        }

        public DbSet<ToprakAnalizi> ToprakAnalizleri { get; set; }
        public DbSet<YaprakAnalizi> YaprakAnalizleri { get; set; }
        public DbSet<SuAnaliz> SuAnalizleri { get; set; }
        public DbSet<SuKaynagi> SuKaynaklari { get; set; }
        public DbSet<Tarla> Tarlalar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<SensorVerisi> SensorVerileri { get; set; }
        public DbSet<UrunTavsiyesi> UrunTavsiyeleri { get; set; }
        public DbSet<GubreOnerisi> GubreOnerileri { get; set; }
        public DbSet<VerimTahmini> VerimTahminleri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Toprak Analizi - Tarla Iliskisi
            modelBuilder.Entity<ToprakAnalizi>()
                .HasOne(t => t.Tarla)
                .WithMany(t => t.ToprakAnalizleri)
                .HasForeignKey(t => t.TarlaId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // Yaprak Analizi - Tarla Iliskisi
            modelBuilder.Entity<YaprakAnalizi>()
                .HasOne(y => y.Tarla)
                .WithMany(t => t.YaprakAnalizleri)
                .HasForeignKey(y => y.TarlaId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // Su Analizi - Tarla Iliskisi
            modelBuilder.Entity<SuAnaliz>()
                .HasOne(s => s.Tarla)
                .WithMany(t => t.SuAnalizleri)
                .HasForeignKey(s => s.TarlaId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // VerimTahmini - Tarla Iliskisi
            modelBuilder.Entity<VerimTahmini>()
                .HasOne(v => v.Tarla)
                .WithMany()
                .HasForeignKey(v => v.TarlaId)
                .OnDelete(DeleteBehavior.Cascade);

            // GubreOnerisi - Tarla Iliskisi
            modelBuilder.Entity<GubreOnerisi>()
                .HasOne(g => g.Tarla)
                .WithMany()
                .HasForeignKey(g => g.TarlaId)
                .OnDelete(DeleteBehavior.Cascade);

            // UrunTavsiyesi - Tarla Iliskisi
            modelBuilder.Entity<UrunTavsiyesi>()
                .HasOne(u => u.Tarla)
                .WithMany()
                .HasForeignKey(u => u.TarlaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
