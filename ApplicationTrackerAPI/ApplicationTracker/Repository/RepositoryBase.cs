using ApplicationTracker.Contract;
using Microsoft.EntityFrameworkCore;

namespace ApplicationTracker.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationContext _applicationContext;   

        protected RepositoryBase(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public T? FindById(int id) => _applicationContext.Set<T>().Find(id); 
        public IQueryable<T> GetAll() => _applicationContext.Set<T>();
        public void Create(T entity) => _applicationContext.Set<T>().Add(entity);
        public void Update(T entity) => _applicationContext.Set<T>().Update(entity);
        public void Delete(T entity) => _applicationContext.Set<T>().Remove(entity);
    }
}
