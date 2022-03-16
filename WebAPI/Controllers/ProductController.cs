using AutoMapper;
using Business.Abstract;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        IMapper _mapper;
        //ICacheManager _memoryCache;
        public ProductController(IProductService productService, IMapper mapper/*, ICacheManager memoryCache*/)
        {
            _productService = productService;
            _mapper = mapper;
            //_memoryCache = memoryCache;
        }
        [HttpPost]
        public IActionResult Add([FromBody] ProductDto productDto)
        {
            var result = _productService.AddProduct(_mapper.Map<Product>(productDto));
            return Ok(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromBody] ProductUpdateDto productUpdateDto)
        {
            _productService.UpdateProduct(_mapper.Map<Product>(productUpdateDto));
            return Ok();
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromBody] ProductDeleteDto productDeleteDto)
        {
            _productService.DeleteProduct(_mapper.Map<Product>(productDeleteDto));
            return Ok();
        }
        [HttpGet("getbyid")]
        public IActionResult GetByProductId(int productId)
        {
            var result = _productService.GetProductByProductId(productId);
            return Ok(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAllProducts()
        {
            #region Aspect Olmadan Önce Cache Yazımı
            //const string cacheKey = "pKey";

            ////object service =

            //object productList;
            //if (!_memoryCache.TryGetValue(cacheKey, out productList))
            //{
            //    productList = _productService.GetAllProducts();
            //    //productList = new List<Product>() { new Product() { } };
            //    var cacheExpOptions = new MemoryCacheEntryOptions
            //    {
            //        SlidingExpiration = TimeSpan.FromMinutes(2),
            //        Priority = CacheItemPriority.Normal
            //    };
            //    _memoryCache.Set(cacheKey, productList, cacheExpOptions);
            //}

            //return Ok(productList);
            #endregion
            var result = _productService.GetAllProducts();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getproductsbycategoryid")]
        public IActionResult GetProductsByCategoryId(int id)
        {
            var result = _productService.GetProductsByCategoryId(id);
            return Ok(result);
        }
    }
}
