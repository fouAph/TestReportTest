namespace NorthwindWebMvc.Basic.Repository
{
    public interface IRepositoryBaseNew<TEntity>
    {
        IEnumerable<TEntity> FindAll();

        TEntity FindById(int id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);

    }
}
