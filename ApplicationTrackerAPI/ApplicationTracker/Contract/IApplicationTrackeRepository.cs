using ApplicationTracker.Models;

namespace ApplicationTracker.Contract
{
    public interface IApplicationTrackeRepository
    {
        IEnumerable<Application> GetAllApplications();

        Application? FindApplicationById(int id);
        void CreateApplication(Application application);


    }
}
