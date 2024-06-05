using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesempeno.Dto
{
    public class TeacherDto
    {
        [Required (ErrorMessage = "Name is required")]
        public string Names { get; set; }
        [Required (ErrorMessage = "Specialty is required")]
        public string Specialty { get; set; }
        [Required (ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
        [Required (ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required (ErrorMessage = "Year experience is required")]
        public int YearsExperience { get; set; }
    }
}