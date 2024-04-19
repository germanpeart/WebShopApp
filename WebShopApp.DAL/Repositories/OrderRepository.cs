using WebShopApp.DAL.Data;
using WebShopApp.DAL.Interfaces;
using WebShopApp.DAL.Models;

namespace WebShopApp.DAL.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(WebShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
