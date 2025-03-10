using ApplicationTracker.Contract;
using ApplicationTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationTracker.Repository
{
    public class ApplicationTrackeRepository : RepositoryBase<Application>, IApplicationTrackeRepository
    {
        public ApplicationTrackeRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public void CreateApplication(Application application) => Create(application);

        public Application? FindApplicationById(int id) => FindById(id);

        public  IEnumerable<Application> GetAllApplications() => GetAll().ToList();
       
    }
}
