﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            //eager loading=>henüz data(product) çekilirken category alındığı için eager loading yapıldı
            //ihtiyaç olunması halinde data çekilirse bu da lazy loading olur
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
