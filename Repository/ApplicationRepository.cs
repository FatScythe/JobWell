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

        public async Task<ServiceResponse> GetApplications(string userId)
        {
            var applications = await _context.Applications.Where(app => app.AccountId == userId).ToListAsync();

            _response.StatusCode = 200;
            _response.Message = "Users application";
            _response.Result = applications;

            return _response;
        }

        public async Task<ServiceResponse> GetApplicationById(string applicationId)
        {
            var application = await _context.Applications.Where(app => app.Id == applicationId).FirstOrDefaultAsync();

            if (application is null)
            {
                _response.StatusCode = 404;
                _response.Message = $"Application with id: {applicationId} was not found";
                _response.Result = null;

                return _response;
            }

            _response.StatusCode = 200;
            _response.Message = "User Application";
            _response.Result = application;

            return _response;
        }
        public async Task<ServiceResponse> UpdateApplicationById(string applicationId, Application updateApp)
        {
            var application = await _context.Applications.Where(app => app.Id == applicationId).FirstOrDefaultAsync();

            if (application is null)
            {
                _response.StatusCode = 404;
                _response.Message = $"Application with id: {applicationId} was not found";
                _response.Result = null;

                return _response;
            }

            application.FirstName = updateApp.FirstName;
            application.LastName = updateApp.LastName;
            application.Email = updateApp.Email;
            application.MiddleName = updateApp.MiddleName;
            application.Address = updateApp.Address;
            application.Mobile = updateApp.Mobile;
            application.Resume = updateApp.Resume;
            application.DoB = updateApp.DoB;
            application.Gender = updateApp.Gender;
            application.UpdatedAt = DateTime.Now;

            if(await _context.SaveChangesAsync() < 1)
            {
                _response.StatusCode = 500;
                _response.Message = "Something went wrong, unable to update application";
                _response.Result = null;
            }

            _response.StatusCode = 200;
            _response.Message = "Application updated";
            _response.Result = application;

            return _response;
        }

        public async Task<ServiceResponse> DeleteApplicationById(string applicationId)
        {
            var application = await _context.Applications.FindAsync(applicationId);

            if (application is null)
            {
                _response.StatusCode = 404;
                _response.Message = $"Application with id: {applicationId} was not found";
                _response.Result = null;

                return _response;
            }

            _context.Applications.Remove(application);

            if (await _context.SaveChangesAsync() < 1)
            {
                _response.StatusCode = 500;
                _response.Message = "Something went wrong, unable to delete applcation";
                _response.Result = null;
            }

            _response.StatusCode = 200;
            _response.Message = "Application updated";
            _response.Result = application;

            return _response;
        }

    }
}
