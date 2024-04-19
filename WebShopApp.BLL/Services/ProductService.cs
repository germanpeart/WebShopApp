using AutoMapper;
using WebShopApp.BLL.Interfaces;
using WebShopApp.DAL.DTOs;
using WebShopApp.DAL.Interfaces;
using WebShopApp.DAL.Models;

namespace WebShopApp.BLL.Services
{
    public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _productRepository.Get(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> Add(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            // Get the latest product code and increment it by 1
            string code = await _productRepository.GetLatestCode();
            _ = int.TryParse(code.AsSpan(5), out int codeNumber);
            codeNumber++;
            product.Code = "ECHO-" + codeNumber.ToString("D5");

            await _productRepository.Add(product);
            return await GetById(product.ProductId);
        }

        public async Task Update(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.Update(product);
        }

        public async Task Delete(int id)
        {
            await _productRepository.Delete(id);
        }
    }
}
