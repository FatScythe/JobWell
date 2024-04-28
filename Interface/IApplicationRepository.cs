using server.Dto;
using server.Models;

namespace server.Interface
{
    public interface IApplicationRepository
    {
        Task<ServiceResponse> GetApplications(string userId);
        Task<ServiceResponse> GetApplicationById(int applicationId);
        Task<ServiceResponse> CreateApplicationAsync(Application application);
        Task<ServiceResponse> UpdateApplicationId(Application application);
        Task<ServiceResponse> DeleteApplicationById(int applicationId);
    }
}
