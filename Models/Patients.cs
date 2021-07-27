using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorManagement.Models
{
    public class Patients
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ClinicalRemarks { get; set; }
        public string Diagnosis { get; set; }
        public string Therapy { get; set; }
    }
}
