using server.Dto.Job;
using server.Models;

namespace server.Interface
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllJobs();
        Task<Job?> GetJobById(int jobId);
        Task<Job?> CreateJob(Job job);
        Task<Job?> UpdateJob(int Job, UpdateJobDto job);
        Task<Job?> DeleteJobById(int jobId);
    }
}
