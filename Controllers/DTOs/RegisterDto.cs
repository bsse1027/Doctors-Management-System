using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorManagement.Controllers.DTOs
{
    public class RegisterDto
    {

        [Required]
        public string DoctorName { get; set; }

        [Required]
        public string HospitalName { get; set; }

        [Required]
        public string Designation { get; set; }
        
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
