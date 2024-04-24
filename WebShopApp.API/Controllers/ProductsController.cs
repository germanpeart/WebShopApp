using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebShopApp.BLL.Interfaces;
using WebShopApp.DAL.DTOs;
using WebShopApp.Utilities.Helpers;

namespace WebShopApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService, IMemoryCache memoryCache) : ControllerBase
    {
        private readonly IProductService _productService = productService;
        private readonly IMemoryCache _memoryCache = memoryCache;

        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                if (_memoryCache.TryGetValue("allProducts", out IEnumerable<ProductDto>? products))
                    return Ok(products);

                products = await _productService.GetAll();

                if (products is null)
                    return NotFound("No products found");

                _memoryCache.Set("allProducts", products, TimeSpan.FromMinutes(10));

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ExceptionHelper.GetInnerMessage(ex)}");
            }
        }

        // GET: api/Products/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var product = await _productService.GetById(id);

                if (product is null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ExceptionHelper.GetInnerMessage(ex)}");
            }
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            try
            {
                if (productDto is null)
                    return BadRequest("Product object is null");

                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");

                var product = await _productService.Add(productDto);
                _memoryCache.Remove("allProducts");
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ExceptionHelper.GetInnerMessage(ex)}");
            }
        }

        // PUT: api/Products/
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDto productDto)
        {
            try
            {
                if (productDto is null)
                    return BadRequest("Product object is null");

                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");

                await _productService.Update(productDto);
                _memoryCache.Remove("allProducts");
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ExceptionHelper.GetInnerMessage(ex)}");
            }
        }

        // DELETE: api/Products/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.Delete(id);
                _memoryCache.Remove("allProducts");
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ExceptionHelper.GetInnerMessage(ex)}");
            }
        }
    }
}
