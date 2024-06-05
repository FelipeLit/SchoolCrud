using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Services.Students;

namespace PruebaDesempeno.Controllers.Students
{
    public class StudentControllers : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentControllers(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("students")]
        public IActionResult GetAllStudents ()
        {
            try
            {
                 var students = _studentRepository.GetAllStudents();
                if (students.Count()<1)
                {
                    return NotFound("Not found students");
                }
                else
                {
                    return Ok(students);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("students/{id}")]
        public IActionResult GetStudent (int id)
        {
            try 
            {
                 var student = _studentRepository.GetStudentById(id);
                if (student != null)
                {
                    return Ok(student);
                }
                else
                {
                    return NotFound("Student was not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet]
        [Route("students/birthday")]
        public IActionResult FilterStudentByBirthDate([FromBody] DateRequest dateRequest)
        {
            try
            {
                var fecha = new DateTime (dateRequest.Year, dateRequest.Month, dateRequest.Day);
                var students = _studentRepository.FilterStudentByBirthDate(fecha.Date);
                if (students.Count()<1)
                {
                    return NotFound("There is not students for specified date");
                }
                return Ok(students);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}

