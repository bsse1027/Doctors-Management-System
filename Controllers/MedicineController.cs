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

        //api/medicine/add

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


        //GetALL
        [Authorize]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Medicines>>> GetAll()
        {
            
            var med = await _db.Medicines.ToListAsync();

            if(med == null)
            {
                return NotFound();
            }

            return med;
        }


        //api/medicine/name

        [Authorize]
        [HttpGet("{name}")]

        public async Task<ActionResult<Medicines>> GetOne(String name)
        {
            try
            {
                var med = await _db.Medicines.SingleOrDefaultAsync(x => x.Name == name);

                return med;

            }

            catch
            {
                return NotFound();
            }
            
            
            //return await _db.Medicines.FindAsync(name);
        }

        //Delete Medicine

        [Authorize]

        // DELETE: api/medicine/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Medicines>> DeleteMedicine(int id)
        {
            var med = await _db.Medicines.FindAsync(id);
            if (med == null)
            {
                return NotFound();
            }

            _db.Medicines.Remove(med);
            await _db.SaveChangesAsync();

            return med;
        }
    }
}
