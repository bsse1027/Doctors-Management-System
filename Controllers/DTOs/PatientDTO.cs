using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorManagement.Controllers.DTOs
{
    public class PatientDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ClinicalRemarks { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        [Required]
        public string Therapy { get; set; }
        
    }
}
