using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesempeno.Services.Teachers;

namespace PruebaDesempeno.Controllers.Teachers
{
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }


        [HttpGet]
        [Route("teachers")]
        public IActionResult GetAllTeachers ()
        {
            try
            {
                 var teachers = _teacherRepository.GetAllteachers();
                if (teachers.Count()<1)
                {
                    return NotFound("Not found teachers");
                }
                else
                {
                    return Ok(teachers);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("teachers/{id}")]
        public IActionResult GetTeacher (int id)
        {
            try 
            {
                 var teacher = _teacherRepository.GetteacherById(id);
                if (teacher != null)
                {
                    return Ok(teacher);
                }
                else
                {
                    return NotFound("teacher was not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}