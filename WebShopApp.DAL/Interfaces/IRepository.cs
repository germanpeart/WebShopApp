namespace WebShopApp.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(int id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
    }
}
