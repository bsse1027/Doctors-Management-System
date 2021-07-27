using DoctorManagement.Data;
using DoctorManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorManagement.Controllers
{
    public class MedicineController : BaseApiController
    {
        private readonly ApplicationDbContext _db;

        public MedicineController(ApplicationDbContext db)
        {
            _db = db;

        }

        [Authorize]
        [HttpPost("add")]

        public async Task<ActionResult<Medicines>> addMed(Medicines med)
        {
            var newMed = new Medicines
            {
                Name = med.Name,
                Indication = med.Indication,
                Usage = med.Usage,
                Instruction = med.Instruction
            };

            _db.Medicines.Add(newMed);
            await _db.SaveChangesAsync();

            return new Medicines
            {
                MedID = newMed.MedID,
                Name = newMed.Name,
                Indication = newMed.Indication,
                Usage = newMed.Usage,
                Instruction = newMed.Instruction
            };
        }



        [Authorize]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Medicines>>> showRegs()
        {
            return await _db.Medicines.ToListAsync();
        }



        [Authorize]
        [HttpGet("{name}")]

        public async Task<ActionResult<Medicines>> GetMedicines(String name)
        {
            var med = await _db.Medicines.SingleOrDefaultAsync(x=>x.Name == name);

            return med;
            
            //return await _db.Medicines.FindAsync(name);
        }
    }
}
