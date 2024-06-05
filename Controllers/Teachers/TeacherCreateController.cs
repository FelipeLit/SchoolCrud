using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Services.Teachers;

namespace PruebaDesempeno.Controllers.Teachers
{
    public class TeacherCreateController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherCreateController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpPost]
        [Route("teachers")]
        public IActionResult CreateTeacher([FromBody] TeacherDto teacherDto)
        {
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _teacherRepository.Addteacher(teacherDto);
                return Ok("New teacher add");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}