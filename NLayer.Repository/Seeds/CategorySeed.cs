using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    //seed işlemi uygulama ayağa kalkerken de, migration işlemi esnasında gerçekleşecek şekilde de yapılabilir.
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        //AppDbContext'te bu işlemler yapılabilir, amaç okunaklı şekilde yazabilmek
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Kalemler" },
                new Category { Id = 2, Name = "Kitaplar" },
                new Category { Id = 3, Name = "Defterler" });
        }
    }
}
