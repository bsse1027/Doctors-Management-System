using DoctorManagement.Controllers.DTOs;
using DoctorManagement.Data;
using DoctorManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorManagement.Controllers
{
    
    public class PatientController : BaseApiController
    {
        private readonly ApplicationDbContext _db;

        public PatientController(ApplicationDbContext db)
        {
            _db = db;

        }

        //GetAll
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patients>>> GetAll()
        {
            return await _db.Patients.ToListAsync();
        }

        //GetPatientByID
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Patients>> GetPatient(int id)
        {
            var Patients = await _db.Patients.FindAsync(id);

            if (Patients == null)
            {
                return NotFound();
            }

            return Patients;
        }

        //Add a patient

        [Authorize]
        [HttpPost]

        public async Task<ActionResult> AddPatient(PatientDTO patient)
        {

            if (ModelState.IsValid)
            {
                var patients = new Patients
                {
                    Name = patient.Name,
                    Sex = patient.Sex,
                    Phone = patient.Phone,
                    Address = patient.Address,
                    ClinicalRemarks = patient.ClinicalRemarks,
                    Diagnosis = patient.Diagnosis,
                    Therapy = patient.Therapy

                };

                _db.Patients.Add(patients);
                await _db.SaveChangesAsync();

                return Ok();

                //return new PatientDTO
                //{
                //    Name = patients.Name,




                //};

            }

            else return BadRequest();

            
        }

        //UpdatePatient

        [Authorize]

        // PUT: api/Patient/5
      
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatients(int id, Patients inputPatient)
        {
            if (id != inputPatient.Id)
            {
                return BadRequest();
            }

            _db.Entry(inputPatient).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if ( await PatientExists(id)==false)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Updated");
        }

        private async Task<bool> PatientExists(int IDen)
        {
            return await _db.Patients.AnyAsync(x => x.Id == IDen);

        }

        //Delete Patient

        [Authorize]

        // DELETE: api/Patient/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patients>> DeletePatient(int id)
        {
            var patient = await _db.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _db.Patients.Remove(patient);
            await _db.SaveChangesAsync();

            return patient;
        }










    }
}
