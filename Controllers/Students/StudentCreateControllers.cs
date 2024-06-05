using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Services.Students;

namespace PruebaDesempeno.Controllers.Students
{
    public class StudentCreateControllers : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentCreateControllers(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPost]
        [Route("students")]
        public IActionResult CreateStudent([FromBody] StudentDto studentDto)
        {
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _studentRepository.AddStudent(studentDto);
                return Ok("New student add");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


    }
}