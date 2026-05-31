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
        public DbSet<SuAnalizi> SuAnalizleri { get; set; }
        public DbSet<Tarla> Tarlalar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<SensorVerisi> SensorVerileri { get; set; }
        public DbSet<UrunTavsiyesi> UrunTavsiyeleri { get; set; }
        public DbSet<GubreOnerisi> GubreOnerileri { get; set; }
        public DbSet<VerimTahmini> VerimTahminleri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================================================================
            // TICARI ESNEKLIK: ANALIZLER ICIN TARLA ZORUNLULUGUNU KALDIRAN FLUENT API
            // =========================================================================

            // 1. Toprak Analizi - Tarla İlişkisi (İsteğe Bağlı / Optional)
            modelBuilder.Entity<ToprakAnalizi>();
                //.HasOne(t => t.Tarla)
                //.WithMany() // Eğer Tarla sınıfında 'public ICollection<ToprakAnalizi> ToprakAnalizleri { get; set; }' varsa parantez içine: x => x.ToprakAnalizleri yazabilirsin.
               // .HasForeignKey(t => t.TarlaId)
               // .IsRequired(false) // TarlaId null olabilir, analiz tarladan bağımsız kaydedilebilir!
                //.OnDelete(DeleteBehavior.SetNull); // Tarla silinirse analiz silinmez, tarla alanı null'a çekilir.

            // 2. Yaprak Analizi - Tarla İlişkisi (İsteğe Bağlı / Optional)
            modelBuilder.Entity<YaprakAnalizi>()
                .HasOne(y => y.Tarla)
                .WithMany() // Eğer Tarla sınıfında koleksiyon varsa parantez içine yazabilirsin.
                .HasForeignKey(y => y.TarlaId)
                .IsRequired(false) // TarlaId null olabilir!
                .OnDelete(DeleteBehavior.SetNull);

            // 3. Su Analizi - Tarla İlişkisi (İsteğe Bağlı / Optional)
            modelBuilder.Entity<SuAnalizi>()
                .HasOne(s => s.Tarla)
                .WithMany()
                .HasForeignKey(s => s.TarlaId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}