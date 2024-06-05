using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesempeno.Dto
{
    public class StudentDto
    {

        [Required (ErrorMessage = "El nombre requerido")]
        public string Names { get; set; }
        [Required (ErrorMessage = "La fecha es requerida")]
        public DateTime BirthDate { get; set; }
        [Required (ErrorMessage = "La direccion es requerida")]
        public string Address { get; set; }
        [Required (ErrorMessage = "El email es requerido")]
        public string Email { get; set; }
    }
}