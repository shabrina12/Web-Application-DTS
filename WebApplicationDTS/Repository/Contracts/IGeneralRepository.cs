namespace WebApplicationDTS.Repository.Contracts
{
    public interface IGeneralRepository<TEntity, TKey>
    {
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(TKey key);
        int Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(TKey key);
    }
}
