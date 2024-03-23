using Newtonsoft.Json;
using server.Dto.Job;
using server.Models;

namespace server.Mappers
{
    public static class JobMappers
    {
        public static Job ToJobFromCreateDto(this CreateJobDto createJob)
        {
            return new Job
            {
                Title = createJob.Title,
                Description = createJob.Description,
                Type = createJob.Type,
                Location = createJob.Location,
                LocationType = createJob.LocationType,
                Tags = JsonConvert.DeserializeObject<string[]>(createJob.Tags),
                Deadline = DateOnly.Parse(createJob.Deadline),
            };

        }
    }
}
