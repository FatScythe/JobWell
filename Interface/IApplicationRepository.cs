using server.Models;

namespace server.Interface
{
    public interface IApplicationRepository
    {
        Task<Application> GetApplications();
        Task<List<Application>> GetApplicationById(int applicationId);
        Task<Application> CreateApplication(Application application);
        Task<Application> UpdateApplicationId(Application application);
        Task<Application> DeleteApplicationById(int applicationId);
    }
}
