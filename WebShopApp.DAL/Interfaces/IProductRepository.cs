using WebShopApp.DAL.Models;

namespace WebShopApp.DAL.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<string> GetLatestCode();
    }
}
