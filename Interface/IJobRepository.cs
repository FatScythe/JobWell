using server.Models;

namespace server.Interface
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllJobsAsync();
        Task<Job> GetJobByIdAsync(int jobId);
        Task<Job> CreateJob(Job job);
        Task<Job> UpdateJobAsync(int Job, Job job);
        Task<Job> DeleteJobById(int jobId);
    }
}
