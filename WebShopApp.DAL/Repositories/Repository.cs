using Microsoft.EntityFrameworkCore;
using WebShopApp.DAL.Data;
using WebShopApp.DAL.Interfaces;

namespace WebShopApp.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly WebShopDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(WebShopDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new InvalidOperationException("Entity is null.");
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await Get(id);
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
