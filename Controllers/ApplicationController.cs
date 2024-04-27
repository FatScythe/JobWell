using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Dto.Application;
using server.Extensions;
using server.Interface;
using server.Models;

namespace server.Controllers
{
    [Route("/api/v1/application")]
    [ApiController]
    public class ApplicationController: ControllerBase
    {
        private readonly IApplicationRepository _appRepo;
        public ApplicationController(IApplicationRepository applicationRepository)
        {
            _appRepo = applicationRepository;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetUserApplications()
        {
            return Ok("Get user application");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetSingleUserApplications(int id)
        {

            return Ok("Get single user application");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateApplication([FromBody] CreateApplicationDto applicationDto)
        {
            if(applicationDto is null)
            {
                return BadRequest("Please provide an application");
            }

            var user = User.GetCurrentUserInfo();

            var application = new Application
            {
                FirstName = applicationDto.FirstName,
                LastName  = applicationDto.LastName,
                MiddleName = applicationDto.MiddleName,
                Email = user.Email,
                Gender = applicationDto.Gender,
                Address = applicationDto.Address,
                Mobile = applicationDto.Mobile,
                DoB = DateOnly.Parse(applicationDto.DoB),
                Resume = applicationDto.Resume,
                AccountId = user.Id,
                JobId = applicationDto.JobId
            };

            var createdApp = await _appRepo.CreateApplicationAsync(application);

            if(createdApp is null)
            {
                return StatusCode(500, new { success = false, message = "Something went wrong" });
            }

            return CreatedAtAction(nameof(GetSingleUserApplications), new { id = createdApp.Id }, new { success = true, application = createdApp });
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditApplication()
        {
            return Ok("Edit single Job application");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteApplication()
        {
            return Ok("Delete single Job application");
        }
    }
}
