using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Models;

namespace PruebaDesempeno.Services.Courses
{
    public interface ICourseRepository
    {
        IEnumerable<Course>GetAllCourses();
        Course GetCourseById(int id);
        void AddCourse(CourseDto courseDto);
        void UpdateCourse(int id, CourseDto courseDto);
         IEnumerable<dynamic>CoursesByTeacher(int id);
    }
}