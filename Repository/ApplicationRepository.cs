using server.Data;
using server.Interface;
using server.Models;

namespace server.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DataContext _context;
        public ApplicationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Application> CreateApplicationAsync(Application application)
        {
           await _context.Applications.AddAsync(application);

            if (_context.SaveChanges() < 1)
                return null;

            return application;
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
