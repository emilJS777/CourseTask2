using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseTask.Src.Services;
using CourseTask.Src.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseTask.Src.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CourseUserController : Controller
    {
        private readonly ICourseUserService courseUserService;
        public CourseUserController(ICourseUserService courseUserService)
        {
            this.courseUserService = courseUserService;
        }
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CourseUserViewModel courseUserViewModel)
        {
            if (ModelState.IsValid)
            {
                string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                var result = courseUserService.Bind(int.Parse(userId), courseUserViewModel);
                if (result == null)
                    return NotFound("User not found");
                return Ok("successfully attached");
            }
            return BadRequest(ModelState);
        }

        // DELETE api/values/5
        [HttpDelete]
        public IActionResult Delete([FromBody]CourseUserViewModel courseUserViewModel)
        {
            if (ModelState.IsValid)
            {
                string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                var result = courseUserService.Unbind(int.Parse(userId), courseUserViewModel);
                if (result == null)
                    return NotFound("User not found");
                return Ok("successfully untied");
            }
            return BadRequest(ModelState);
        }
    }
}

