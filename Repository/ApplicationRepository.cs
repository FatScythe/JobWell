using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dto;
using server.Interface;
using server.Models;

namespace server.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DataContext _context;
        private readonly ServiceResponse _response;
        public ApplicationRepository(DataContext context, ServiceResponse response)
        {
            _context = context;
            _response = response;

        }
        public async Task<ServiceResponse> CreateApplicationAsync(Application application)
        {
           await _context.Applications.AddAsync(application);

            if (_context.SaveChanges() < 1)
            {
                _response.Message = "Unable to create job application";
                _response.StatusCode = 500;
                _response.Result = null;

                return _response;
            }
                

            _response.Message = "Job application created sucessfully";
            _response.StatusCode = 201;
            _response.Result = application;

            return _response;
        }

        public Task<Application> DeleteApplicationById(int applicationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Application>> GetApplicationById(int applicationId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> GetApplications(string userId)
        {
            var applications = await _context.Applications.Where(app => app.AccountId == userId).ToListAsync();

            _response.StatusCode = 200;
            _response.Message = "Users application";
            _response.Result = applications;

            return _response;
        }

        public Task<Application> UpdateApplicationId(Application application)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse> IApplicationRepository.DeleteApplicationById(int applicationId)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse> IApplicationRepository.GetApplicationById(int applicationId)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse> IApplicationRepository.UpdateApplicationId(Application application)
        {
            throw new NotImplementedException();
        }
    }
}
