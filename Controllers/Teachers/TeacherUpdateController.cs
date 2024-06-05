using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Services.Teachers;

namespace PruebaDesempeno.Controllers.Teachers
{
    public class TeacherUpdateController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherUpdateController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpPut]
        [Route("teachers/{id}")]
        public IActionResult Updateteacher (int id, [FromBody]TeacherDto teacherDto)
        {
            try
            {
                var teacherU = _teacherRepository.GetteacherById(id);
                if (teacherU != null)
                {
                    _teacherRepository.UpdateTeacher(id, teacherDto);
                    return Ok ("Teacher was update");
                }
                else
                {
                    return NotFound("Teacher was not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}