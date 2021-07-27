using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorManagement.Models
{
    public class Medicines
    {
        [Key]
        public int MedID { get; set; }
        public String Name { get; set; }

        public String Indication { get; set; }

        public String Usage { get; set; }

        public String Instruction { get; set; }
    }
}
