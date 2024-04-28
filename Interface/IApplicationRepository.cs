using server.Dto;
using server.Models;

namespace server.Interface
{
    public interface IApplicationRepository
    {
        Task<ServiceResponse> GetApplications(string userId);
        Task<ServiceResponse> GetApplicationById(string applicationId);
        Task<ServiceResponse> CreateApplicationAsync(Application application);
        Task<ServiceResponse> UpdateApplicationById(string applicationId, Application application);
        Task<ServiceResponse> DeleteApplicationById(string applicationId);
    }
}
