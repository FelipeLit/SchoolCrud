using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesempeno.Dto;
using PruebaDesempeno.Models;

namespace PruebaDesempeno.Services.Teachers
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher>GetAllteachers();
        Teacher GetteacherById(int id);
        void Addteacher(TeacherDto teacherDto);
        void UpdateTeacher(int id, TeacherDto teacherDto);
    }
}