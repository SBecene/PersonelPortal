using Microsoft.EntityFrameworkCore;
using PersonelPortal.Models;

namespace PersonelPortal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Personel> Personeller => Set<Personel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Personel>().HasData(
                new Personel
                {
                    Id = 1,
                    AdSoyad = "Samet Becene",
                    Unvan = "Teknik Destek Uzmanı",
                    Birim = "Donanım Şube",
                    Telefon = "0537 279 2807"
                },
                new Personel
                {
                    Id = 2,
                    AdSoyad = "Çağrı Arısoy",
                    Unvan = "Yazılımcı",
                    Birim = "Yazılım Geliştirme Şubesi",
                    Telefon = "0500 111 11 11"
                }
            );
        }
    }
}