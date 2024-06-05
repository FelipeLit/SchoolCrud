using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Services.Enrollments;

namespace PruebaDesempeno.Controllers.Enrollments
{
    public class EnrollmentUpdateController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentUpdateController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }
        [HttpPut]
        [Route("enrollments/{id}")]
        public IActionResult UpdateEnrollment (int id, [FromBody]EnrollmentDto enrollmentDto)
        {
            try
            {
                var enrollmentU = _enrollmentRepository.GetEnrollmentById(id);
                if (enrollmentU != null)
                {
                    _enrollmentRepository.UpdateEnrollment(id, enrollmentDto);
                    return Ok ("Enrollment was update");
                }
                else
                {
                    return NotFound("Enrollment was not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}