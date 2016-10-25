namespace ComputersFactory.Data.Repositories.Repositories.Contracts
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        TEntity Get(int id);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}
