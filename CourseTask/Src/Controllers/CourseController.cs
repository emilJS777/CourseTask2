using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseTask.Src.Services;
using CourseTask.Src.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseTask.Src.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly ICourseService courseService;
        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = courseService.Get();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = courseService.Get(id);
            if (result == null)
                return NotFound("Course not found");
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CourseViewModel courseViewModel)
        {
            if(ModelState.IsValid)
            {
                var result = courseService.Create(courseViewModel);
                if (result == false)
                    return Conflict("Course title exist");
                return Ok("Course created");

            }
            return BadRequest(ModelState);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = courseService.Update(id, courseViewModel);
                if (result == null)
                    return NotFound("Course not found");
                if (result == false)
                    return Conflict("Course title exist");
                return Ok("Course updated");

            }
            return BadRequest(ModelState);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = courseService.Delete(id);
            if (result == null)
                return NotFound("Course not found");
            return Ok("Deleted");
        }
    }
}

