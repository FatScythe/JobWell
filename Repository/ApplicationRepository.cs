using server.Interface;
using server.Models;

namespace server.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        public Task<Application> CreateApplication(Application application)
        {
            throw new NotImplementedException();
        }

        public Task<Application> DeleteApplicationById(int applicationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Application>> GetApplicationById(int applicationId)
        {
            throw new NotImplementedException();
        }

        public Task<Application> GetApplications()
        {
            throw new NotImplementedException();
        }

        public Task<Application> UpdateApplicationId(Application application)
        {
            throw new NotImplementedException();
        }
    }
}
