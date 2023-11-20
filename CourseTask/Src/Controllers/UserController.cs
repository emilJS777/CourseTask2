using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseTask.Src.Services;
using CourseTask.Src.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseTask.Src.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly HashSet<string> revokedTokens = new HashSet<string>();

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: api/values
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var result = userService.Get();
            return Ok(result);
        }

        // GET api/values/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = userService.Get(id);
            if (result == null)
                return NotFound("user not found");
            return Ok(result);
        }

        // PUT api/values/5
        [Authorize]
        [HttpPut]
        public IActionResult Put([FromBody]RegistrationViewModel registrationViewModel)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (ModelState.IsValid)
            {
                var result = userService.Update(int.Parse(userId), registrationViewModel);
                if (result == null)
                    return NotFound("user not found");
                if (result == false)
                    return Conflict("username exist");
                return Ok("Updated");
            }
            return BadRequest(ModelState);
        }

        // DELETE api/values/5
        [Authorize]
        [HttpDelete]
        public IActionResult Delete()
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var result = userService.Delete(int.Parse(userId));
            if (result == null)
                return NotFound("user not found");
            return Ok("Deleted");
        }

        // POST api/values
        [HttpPost("Login")]
        public IActionResult Post([FromBody] LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = userService.Login(loginViewModel);
                if (result == null)
                    return BadRequest("Invalid username or password");
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        // POST api/values
        [HttpPost("Registration")]
        public IActionResult Post([FromBody] RegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = userService.Create(registrationViewModel);
                if (result == false)
                    return Conflict("username exist");
                return Ok("user created");
            }
            return BadRequest(ModelState);
        }
    }
}

