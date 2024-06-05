using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesempeno.Data;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Models;

namespace PruebaDesempeno.Services.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _context;
        public CourseRepository(SchoolContext context)
        {
            _context = context;
        }
        public void AddCourse(CourseDto courseDto)
        {
            try
            {
                var course = new Course
                {
                    Name = courseDto.Name,
                    Description = courseDto.Description,
                    Schedule = courseDto.Schedule,
                    Duration = courseDto.Duration,
                    Capacity = courseDto.Capacity,
                    TeacherId = courseDto.TeacherId,
               
                };
                _context.Courses.Add(course);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<dynamic> CoursesByTeacher(int id)
        {
            
            var courses = _context.Courses
            .Where(c => c.TeacherId == id)
            .Select(t => new{
                Teacher = new
                {
                    id = t.TeacherId,
                    Name = t.Teacher.Names
                },
                Course = new[]
                {
                    new 
                    {
                        id = t.Id,
                        name = t.Name,
                        description = t.Description,
                        schedule = t.Schedule,
                        duration = t.Duration,
                        capacity = t.Capacity
                    }
                }
            }).ToList();
             if (courses != null)
            {
                return courses;
            }	
            else
            {
                return null;
            }	
        }

        public IEnumerable<Course> GetAllCourses()
        {
            var courses = _context.Courses.ToList();
            if (courses != null)
            {
                return courses;
            }
            else
            {
                return null;
            }
        }

        public Course GetCourseById(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                return course;
            }
            else
            {
                return null;
            }
        }

        public void UpdateCourse(int id, CourseDto courseDto)
        {
            var courseU = _context.Courses.Find(id);
            if(courseU != null)
            {
                courseU.Name = courseDto.Name;
                courseU.Description = courseDto.Description;
                courseU.Schedule = courseDto.Schedule;
                courseU.Duration = courseDto.Duration;
                courseU.Capacity = courseDto.Capacity;
                courseU.TeacherId = courseDto.TeacherId;
                _context.Courses.Update(courseU);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Course not found");
            }
        }
    }
}