namespace ApplicationTracker.Contract
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll();
        T? FindById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
