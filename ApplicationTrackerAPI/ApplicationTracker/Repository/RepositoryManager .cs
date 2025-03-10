using ApplicationTracker.Contract;

namespace ApplicationTracker.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private ApplicationContext _applicationContext;
        private IApplicationTrackeRepository _applicationTrackerRepo;
        public RepositoryManager(ApplicationContext applicationContext) {
            _applicationContext = applicationContext;
        }

        public IApplicationTrackeRepository TrackeRepository
        {
            get
            {
                if (_applicationTrackerRepo == null)
                    _applicationTrackerRepo = new ApplicationTrackeRepository(_applicationContext);
                return _applicationTrackerRepo;
            }
        }

        public void Save() => _applicationContext.SaveChanges();
    }
}
