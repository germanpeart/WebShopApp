using WebShopApp.DAL.DTOs;

namespace WebShopApp.BLL.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto> GetById(int id);
        Task<ProductDto> Add(ProductDto productDto);
        Task Update(ProductDto productDto);
        Task Delete(int id);
    }
}
