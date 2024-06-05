using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Services.Courses;

namespace PruebaDesempeno.Controllers.Courses
{
    public class CourseUpdateController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseUpdateController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPut]
        [Route("courses/{id}")]
        public IActionResult UpdateCourse (int id, [FromBody]CourseDto courseDto)
        {
            try
            {
                var courseU = _courseRepository.GetCourseById(id);
                if (courseU != null)
                {
                    _courseRepository.UpdateCourse(id, courseDto);
                    return Ok ("Course was update");
                }
                else
                {
                    return NotFound("Course was not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}