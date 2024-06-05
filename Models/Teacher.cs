using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaDesempeno.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Names { get; set; }
        [Required]
        public string Specialty { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int YearsExperience { get; set; }
        [JsonIgnore]
        public List<Course> Courses { get; set; }
    }
}