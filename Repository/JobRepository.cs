using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using server.Data;
using server.Dto.Job;
using server.Interface;
using server.Models;

namespace server.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly DataContext _context;
        public JobRepository(DataContext context) 
        {
            _context = context;
        }
        public async Task<List<Job>> GetAllJobs()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job?> GetJobById(int jobId)
        {
            var job = await _context.Jobs.FindAsync(jobId);

            if(job is null)
                return null;
           
            return job;
        }
        public async Task<Job?> CreateJob(Job job)
        {
            await _context.Jobs.AddAsync(job);

            if(_context.SaveChanges() < 1)
                return null;
            
            return job;
        }
        public async Task<Job?> UpdateJob(int jobId, UpdateJobDto updateJobDto)
        {
            var job = await _context.Jobs.FindAsync(jobId);

            if (job is null)
                return null;

            job.Title = updateJobDto.Title;
            job.Description = updateJobDto.Description;
            job.Tags = JsonConvert.DeserializeObject<string[]>(updateJobDto.Tags);
            job.Type  = updateJobDto.Type;
            job.Location = updateJobDto.Location;
            job.LocationType = updateJobDto.LocationType;
            job.Deadline = DateOnly.Parse(updateJobDto.Deadline);
            job.UpdatedAt = DateTime.Now;

            if (_context.SaveChanges() < 1)
                return null;

            return job;
        }
        public async Task<Job?> DeleteJobById(int jobId)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(job => job.Id == jobId);

            if (job is null)
                return null;

            _context.Remove(job);

            if (_context.SaveChanges() < 1)
                return null;

            return job;
        }
    }
}
