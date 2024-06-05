using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesempeno.Dto
{
    public class CourseDto
    {
        [Required (ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required (ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required (ErrorMessage = "Schedule is required")]
        public string Schedule { get; set; }
        [Required (ErrorMessage = "Duration is required")]
        public string Duration { get; set; }
        [Required (ErrorMessage = "Capacity is required")]
        public int Capacity { get; set; }
        [Required (ErrorMessage = "Id of teacher is required")]
        public int TeacherId { get; set; }
    }
}