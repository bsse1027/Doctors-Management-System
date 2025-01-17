﻿using DoctorManagement.Data;
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
    
    public class UsersController : BaseApiController
    {
        private readonly ApplicationDbContext _db;
        public UsersController(ApplicationDbContext db)
        {
            _db = db;

        }
        [AllowAnonymous]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Doctors>>> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }

        //api/users/3
        [Authorize]
        [HttpGet("{id}")]

        public async Task<ActionResult<Doctors>> GetUsers(int id)
        {
            return await _db.Users.FindAsync(id);
        }

    }
}
