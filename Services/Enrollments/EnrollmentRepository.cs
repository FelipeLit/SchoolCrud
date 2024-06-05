using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaDesempeno.Data;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Models;
using PruebaDesempeno.Services.Emails;

namespace PruebaDesempeno.Services.Enrollments
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly SchoolContext _context;
        private readonly IMailService _mailService;
        public EnrollmentRepository(SchoolContext context, IMailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }
        public async Task AddEnrollment(EnrollmentDto enrollmentDto)
        {
            try
            {
                var enrollment = new Enrollment
                {
                    Date = enrollmentDto.Date,
                    Status = enrollmentDto.Status,
                    StudentId = enrollmentDto.StudentId,
                    CourseId = enrollmentDto.CourseId
                };
                _context.Enrollments.Add(enrollment);
                await _context.SaveChangesAsync();

                var student = await _context.Students.FindAsync(enrollmentDto.StudentId);
                if (student != null)
                {
                    string subject = "Matricula";
                string body = $"{student.Names} su matricula fue creada con exito en la fecha: {enrollment.Date}";
                await _mailService.SendEmailAsync(student.Email, subject, body);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<dynamic> EnrollmentByStudnet(int id)
        {
            var enrollments = _context.Enrollments
                .Where(s => s.StudentId == id)
                .Select(e => new
                {
                    Student = new
                    {
                        id = e.StudentId,
                        name = e.Student.Names
                    },
                    Enrollment = new[]
                    {
                        new
                        {
                            id = e.Id,
                            date = e.Date,
                            course = e.CourseId,
                            status = e.Status
                        }
                    }
                }).ToList();
            if (enrollments != null)
            {
                return enrollments;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Enrollment> EnrollmentsByDate(DateTime dateTime)
        {
            var enrollments = _context.Enrollments.Where(e => e.Date.Date == dateTime.Date).ToList();
            if (enrollments != null)
            {
                return enrollments;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Enrollment> GetAllEnrollments()
        {
            var enrollments = _context.Enrollments.ToList();
            if (enrollments != null)
            {
                return enrollments;
            }
            else
            {
                return null;
            }
        }

        public Enrollment GetEnrollmentById(int id)
        {
            var enrollment = _context.Enrollments.Find(id);
            if (enrollment != null)
            {
                return enrollment;
            }
            else
            {
                return null;
            }
        }

        public void UpdateEnrollment(int id, EnrollmentDto enrollmentDto)
        {
            var enrollmentU = _context.Enrollments.Find(id);
            if (enrollmentU != null)
            {
                enrollmentU.Date = enrollmentDto.Date;
                enrollmentU.Status = enrollmentDto.Status;
                enrollmentU.StudentId = enrollmentDto.StudentId;
                enrollmentU.CourseId = enrollmentDto.CourseId;
                _context.Enrollments.Update(enrollmentU);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Enrollment not found");
            }
        }
    }
}