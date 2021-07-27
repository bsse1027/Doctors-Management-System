using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorManagement.Models
{
    public class Doctors
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }

        public string DoctorName { get; set; }

        public string HospitalName { get; set; }

        public string Designation { get; set; }


        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }

}
