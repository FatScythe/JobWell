using server.Interface;
using server.Models;

namespace server.Repository
{
    public class JobRepository : IJobRepository
    {
        public Task<Job> CreateJob(Job job)
        {
            throw new NotImplementedException();
        }

        public Task<Job> DeleteJobById(int jobId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Job>> GetAllJobsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Job> GetJobByIdAsync(int jobId)
        {
            throw new NotImplementedException();
        }

        public Task<Job> UpdateJobAsync(int Job, Job job)
        {
            throw new NotImplementedException();
        }
    }
}
