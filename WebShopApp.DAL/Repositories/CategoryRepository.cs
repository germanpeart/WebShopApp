using WebShopApp.DAL.Data;
using WebShopApp.DAL.Interfaces;
using WebShopApp.DAL.Models;

namespace WebShopApp.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(WebShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
