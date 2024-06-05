using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesempeno.Services.Courses;

namespace PruebaDesempeno.Controllers.Courses
{
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        [Route("courses")]
        public IActionResult GetAllCourses ()
        {
            try
            {
                 var courses = _courseRepository.GetAllCourses();
                if (courses.Count()<1)
                {
                    return NotFound("Not found courses");
                }
                else
                {
                    return Ok(courses);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("courses/{id}")]
        public IActionResult Getcourse (int id)
        {
            try 
            {
                 var course = _courseRepository.GetCourseById(id);
                if (course != null)
                {
                    return Ok(course);
                }
                else
                {
                    return NotFound("course was not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpGet]
        [Route("teachers/{id}/courses")]
        public IActionResult GetAllCoursesByTeacher (int id)
        {
            try
            {
                 var courses = _courseRepository.CoursesByTeacher(id);
                if (courses.Count()<1)
                {
                    return NotFound("Not found courses");
                }
                else
                {
                    return Ok(courses);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}