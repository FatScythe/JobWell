﻿using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> GetUserApplications()
        {
            var user = User.GetCurrentUserInfo();
            var result = await _appRepo.GetApplications(user.Id);

            if (result.Result is null)
            {
                return StatusCode(result.StatusCode, new { success = false, message = result.Message });
            }

            return Ok(new { success = true, applications = result.Result });
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetSingleUserApplications([FromRoute]string id)
        {
            var result = await _appRepo.GetApplicationById(id);

            if (result.Result is null)
            {
                return StatusCode(result.StatusCode, new { success = false, message = result.Message });
            }

            return Ok(new { success = true, application = result.Result });
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

            var result = await _appRepo.CreateApplicationAsync(application);

            if(result.Result is null)
            {
                return StatusCode(result.StatusCode, new { success = false, message = result.Message });
            }

            return CreatedAtAction(nameof(GetSingleUserApplications), new { id = application.Id }, new { success = true, application = result.Result });
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
