using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesempeno.Dto
{
    public class EnrollmentDto
    {
        [Required(ErrorMessage ="Date is required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage ="Status is required")]
        public string Status { get; set; }
        [Required(ErrorMessage ="Id of student is required")]
        public int StudentId { get; set; }
        [Required(ErrorMessage ="Id of course is required")]
        public int CourseId { get; set; }
    }
}