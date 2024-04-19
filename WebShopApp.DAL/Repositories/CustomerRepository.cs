using WebShopApp.DAL.Data;
using WebShopApp.DAL.Interfaces;
using WebShopApp.DAL.Models;

namespace WebShopApp.DAL.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(WebShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
