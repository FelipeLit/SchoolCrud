using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesempeno.Data;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Models;

namespace PruebaDesempeno.Services.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;
        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }
        public void AddStudent(StudentDto studentDto)
        {
            try
            {
                var student = new Student
                {
                    Names = studentDto.Names,
                    BirthDate = studentDto.BirthDate,
                    Address = studentDto.Address,
                    Email = studentDto.Email
                };
                _context.Students.Add(student);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Student> FilterStudentByBirthDate(DateTime dateTime)
        {
            var students = _context.Students.Where(e => e.BirthDate.Date == dateTime.Date).ToList();
            if (students != null)
            {
                return students;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            var students = _context.Students.ToList();
            if (students != null)
            {
                return students;
            }
            else
            {
                return null;
            }
        }

        public Student GetStudentById(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                return student;
            }
            else
            {
                return null;
            }
        }

        public void UpdateStudent(int id, StudentDto studentDto)
        {
            var studentU = _context.Students.Find(id);
            if(studentU != null)
            {
                studentU.Names = studentDto.Names;
                studentU.BirthDate = studentDto.BirthDate;
                studentU.Address = studentDto.Address;
                studentU.Email = studentDto.Email;
                _context.Students.Update(studentU);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Student not found");
            }
        }
    }
}