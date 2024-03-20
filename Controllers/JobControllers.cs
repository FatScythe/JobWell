using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("/api/v1/jobs")]
    [ApiController]
    public class JobControllers: ControllerBase
    {
        [HttpGet, Authorize]
        public async Task<IActionResult> GetJobs()
        {
            return Ok("Get All Jobs");
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetJob()
        {
            return Ok("Get Single Jobs");
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob()
        {
            return Ok("Create Job");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateJob()
        {
            return Ok("Update Job");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteJob()
        {
            return NoContent();        
        }
    }
}
