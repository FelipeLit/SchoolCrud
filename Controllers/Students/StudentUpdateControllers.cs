using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Services.Students;

namespace PruebaDesempeno.Controllers.Students
{
    public class StudentUpdateControllers : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentUpdateControllers(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPut]
        [Route("student/{id}")]
        public IActionResult UpdateStudent (int id, [FromBody]StudentDto studentDto)
        {
            try
            {
                var studentU = _studentRepository.GetStudentById(id);
                if (studentU != null)
                {
                    _studentRepository.UpdateStudent(id, studentDto);
                    return Ok ("Student was update");
                }
                else
                {
                    return NotFound("Student not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}