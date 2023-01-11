using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)//options ile veritabanı yolu startup üzerinden verilir
        {
            //var p = new Product() { ProductFeature = new ProductFeature() { } };// istenirse ProductFeature DbSet kaldırılır ve ProductFeature'un Product üzerinden eklenmesi sağlanır
        }
        //her bir entity'e karşılık bir DbSet oluşturulur
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }// istenirse ProductFeature DbSet kaldırılır ve ProductFeature'un Product üzerinden eklenmesi sağlanır

        //EntityTypeConfigurationAttribute yapılmasının sebebi default olarak tanımlanan nvarchar(max) gibi ifadeleri optimize etmek
        //bununla beraber foreign key benzeri ayarlamalar burada da yapılabilir

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //tüm configuration dosyalarını kontrol et,IEntityTypeConfiguration'ı implement eden tüm class'ları bul
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            //modelBuilder.Entity<Category>().HasKey(x => x.Id).HasName("Category");
            //her bir entity ile ilgili ayarın ayrı bir class'ta yapılması kararlaştırıldı


            //bu alanda nasıl seed data yapılacağını görmek amacıyla uygulandı
            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Kırmızı",
                Height = 100,
                Width = 100,
                ProductId = 1,
            },
            new ProductFeature()
            {
                Id = 2,
                Color = "mor",
                Height = 30,
                Width = 33,
                ProductId = 2,
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
