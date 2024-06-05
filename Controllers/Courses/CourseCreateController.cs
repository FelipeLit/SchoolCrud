using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Services.Courses;

namespace PruebaDesempeno.Controllers.Courses
{
    public class CourseCreateController : ControllerBase
    {
       private readonly ICourseRepository _courseRepository;
        public CourseCreateController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPost]
        [Route("courses")]
        public IActionResult CreateCourse([FromBody] CourseDto courseDto)
        {
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _courseRepository.AddCourse(courseDto);
                return Ok("New course add");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        } 
    }
}