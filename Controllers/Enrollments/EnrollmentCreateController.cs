using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Services.Enrollments;

namespace PruebaDesempeno.Controllers.Enrollments
{
    public class EnrollmentCreateController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentCreateController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpPost]
        [Route("enrollments")]
        public async Task<IActionResult> CreateEnrollment([FromBody] EnrollmentDto enrollmentDto)
        {
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _enrollmentRepository.AddEnrollment(enrollmentDto);
                return Ok("New enrollment add");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        } 
    }
}