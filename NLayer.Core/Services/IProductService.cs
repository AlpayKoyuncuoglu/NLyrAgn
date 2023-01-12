using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IProductService : IService<Product>
    {
        //Task<List<ProductWithCategoryDto>> GetProductsWithCategory();
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory();
    }
}
