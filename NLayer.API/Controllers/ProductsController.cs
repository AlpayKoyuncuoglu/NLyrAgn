using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        //private readonly IService<Product> _service;
        //private readonly IProductService _productService;
        private readonly IProductService _service;
        public ProductsController(IService<Product> service, IMapper mapper,IProductService productService)
        {
            //this.productService = productService; yerine;
            //_productService = productService;
            //_service = service;
            _service = productService;
            _mapper = mapper;
        }

        //[HttpGet("GetProductsWithCategory")]//metodun ismini buraya yazmaktan aşağıdaki kullanım tercih edilmiştir
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            //aşağıda 3 satırda yapılan burada 1 satırda yapıldı, özelleştirilmiş bir repo kullanılıyor
            return CreateActionResult(await _service.GetProductsWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }
        //get   /api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(product);
            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)//baseEntity içindeki createdDate'e ihtiyaç yok, productDto kullanılmadı
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            //if(product==null)
            //{
            //    return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404,"bu id'ye sahip ürün bulunamadı"));
            //}
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
