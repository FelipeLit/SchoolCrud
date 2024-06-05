using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Models;

namespace PruebaDesempeno.Services.Enrollments
{
    public interface IEnrollmentRepository
    {
        IEnumerable<Enrollment>GetAllEnrollments();
        Enrollment GetEnrollmentById(int id);
        Task AddEnrollment(EnrollmentDto enrollmentDto);
        // void AddEnrollment(EnrollmentDto enrollmentDto);

        void UpdateEnrollment(int id, EnrollmentDto enrollmentDto);
        IEnumerable<Enrollment>EnrollmentsByDate(DateTime dateTime);
         IEnumerable<dynamic>EnrollmentByStudnet(int id);

    }
}