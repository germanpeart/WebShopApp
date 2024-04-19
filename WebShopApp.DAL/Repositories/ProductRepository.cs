using Microsoft.EntityFrameworkCore;
using WebShopApp.DAL.Data;
using WebShopApp.DAL.Interfaces;
using WebShopApp.DAL.Models;

namespace WebShopApp.DAL.Repositories
{
    public class ProductRepository(WebShopDbContext dbContext) : Repository<Product>(dbContext), IProductRepository
    {
        public async Task<string> GetLatestCode()
        {
            return await _dbSet.OrderByDescending(p => p.Code).Select(p => p.Code).FirstOrDefaultAsync() ?? string.Empty;
        }
    }
}
