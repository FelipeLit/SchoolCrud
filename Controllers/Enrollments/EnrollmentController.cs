using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Services.Enrollments;

namespace PruebaDesempeno.Controllers.Enrollments
{
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }
        [HttpGet]
        [Route("enrollments")]
        public IActionResult GetAllEnrollments ()
        {
            try
            {
                 var enrollments = _enrollmentRepository.GetAllEnrollments();
                if (enrollments.Count()<1)
                {
                    return NotFound("Not found enrollments");
                }
                else
                {
                    return Ok(enrollments);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("enrollments/{id}")]
        public IActionResult GetEnrollment (int id)
        {
            try 
            {
                 var enrollment = _enrollmentRepository.GetEnrollmentById(id);
                if (enrollment != null)
                {
                    return Ok(enrollment);
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

        [HttpGet]
        [Route("enrollments/date")]
        public IActionResult GetCitasByMedico([FromQuery] DateRequest dateRequest)
        {
            try
            {
                var fecha = new DateTime (dateRequest.Year, dateRequest.Month, dateRequest.Day);
                var enrollments = _enrollmentRepository.EnrollmentsByDate(fecha.Date);
                if (enrollments.Count()<1)
                {
                    return NotFound("There is not enrollments for specified date");
                }
                return Ok(enrollments);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("students/{id}/enrollments")]
        public IActionResult GetAllEnrollmentByStudent (int id)
        {
            try
            {
                 var enrollment = _enrollmentRepository.EnrollmentByStudnet(id);
                if (enrollment.Count()<1)
                {
                    return NotFound("Not found enrollment");
                }
                else
                {
                    return Ok(enrollment);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}