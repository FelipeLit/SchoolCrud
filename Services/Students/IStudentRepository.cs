using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Models;

namespace PruebaDesempeno.Services.Students
{
    public interface IStudentRepository
    {
        IEnumerable<Student>GetAllStudents();
        Student GetStudentById(int id);
        void AddStudent(StudentDto studentDto);
        void UpdateStudent(int id, StudentDto studentDto);
        IEnumerable<Student>FilterStudentByBirthDate(DateTime dateTime);
    }
}