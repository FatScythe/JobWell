using server.Dto.Job;
using server.Interface;
using server.Models;

namespace server.Repository
{
    public class JobRepository : IJobRepository
    {
        public Task<Job> CreateJob(CreateJobDto job)
        {
            throw new NotImplementedException();
        }

        public Task<Job> DeleteJobById(int jobId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Job>> GetAllJobs()
        {
            throw new NotImplementedException();
        }

        public Task<Job> GetJobById(int jobId)
        {
            throw new NotImplementedException();
        }

        public Task<Job> UpdateJob(int Job, UpdateJobDto job)
        {
            throw new NotImplementedException();
        }
    }
}
