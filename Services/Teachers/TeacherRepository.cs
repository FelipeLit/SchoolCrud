using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesempeno.Data;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Models;

namespace PruebaDesempeno.Services.Teachers
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolContext _context;
        public TeacherRepository(SchoolContext context)
        {
            _context = context;
        }
        public void Addteacher(TeacherDto teacherDto)
        {
            try
            {
                var teacher = new Teacher
                {
                    Names = teacherDto.Names,
                    Specialty = teacherDto.Specialty,
                    Phone = teacherDto.Phone,
                    Email = teacherDto.Email,
                    YearsExperience = teacherDto.YearsExperience
                };
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Teacher> GetAllteachers()
        {
            var teachers = _context.Teachers.ToList();
            if (teachers != null)
            {
                return teachers;
            }
            else
            {
                return null;
            }
        }

        public Teacher GetteacherById(int id)
        {
            var teachers = _context.Teachers.Find(id);
            if (teachers != null)
            {
                return teachers;
            }
            else
            {
                return null;
            }
        }

        public void UpdateTeacher(int id, TeacherDto teacherDto)
        {
           var teacherU = _context.Teachers.Find(id);
            if(teacherU != null)
            {
                teacherU.Names = teacherDto.Names;
                teacherU.Specialty = teacherDto.Specialty;
                teacherU.Phone = teacherDto.Phone;
                teacherU.Email = teacherDto.Email;
                teacherU.YearsExperience = teacherDto.YearsExperience;
                _context.Teachers.Update(teacherU);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Teacher not found");
            }
        }
    }
}