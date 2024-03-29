using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.Dto.Job;
using server.Extensions;
using server.Interface;
using server.Mappers;
using server.Models;
using System.Data;

namespace server.Controllers
{
    [Route("/api/v1/jobs")]
    [ApiController]
    public class JobControllers: ControllerBase
    {
        private readonly IJobRepository _jobRepo;
        public JobControllers(IJobRepository jobRepository)
        {
            _jobRepo = jobRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Job>>> GetJobs()
        {
            var jobs = await _jobRepo.GetAllJobs();

            return Ok(new { success = true, jobs});
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Job>> GetJob(int id)
        {
            if (id <= 0)
                return BadRequest(new {success = false, message= "Please provide a valid job id"});

            var job = await _jobRepo.GetJobById(id);

            if (job is null)
                return NotFound(new { success = false, message = $"Job with id {id} was not found" });


            return Ok(new {success = true, job });
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employer")]
        public async Task<IActionResult> CreateJob(CreateJobDto createJob)
        {
            if (createJob is null)
               return BadRequest(new { success = false, message = "Please provide fields" });

            if (!ModelState.IsValid)
                return BadRequest(new { success = false, message = "Please fill all fields", error = ModelState });

            var job = await _jobRepo.CreateJob(createJob.ToJobFromCreateDto());

            if (job is null)
                return StatusCode(500, new { success = false, message = "Something went wrong" });

            return CreatedAtAction(nameof(GetJob), new { id = job.Id }, new { success = true, job });
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin, Employer")]
        public async Task<IActionResult> UpdateJob(int id,[FromBody] UpdateJobDto updateJob)
        {
            if (id <= 0)
                return BadRequest(new { success = false, message = "Please provide a valid job id" });

            if (updateJob is null)
                return BadRequest(new { success = false, message = "Please provide update fields" });

            if (!ModelState.IsValid)
                return BadRequest(new { success = false, message = "Please fill all fields", error = ModelState });

            var job = await _jobRepo.UpdateJob(id, updateJob);

            if (job is null)
                return NotFound(new { success = false, message = $"Job with id {id} was not found" });

            return Ok(new {success = true, message = "Job updated", job });
        }

        [HttpDelete("{id:int}"), Authorize(Roles = "Admin, Employer")]
        public async Task<IActionResult> DeleteJob([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest(new { success = false, message = "Please provide a valid job id" });

            var job = await _jobRepo.DeleteJobById(id);

            if (job is null)
                return NotFound(new { success = false, message = $"Job with id {id} was not found" });

            return Ok(new { success = true, message = "Job deleted", job });
        }
    }
}
