using DatingApp.Data;
using DatingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public UsersController(ApplicationDbContext db)
        {
            _db = db;

        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }

        //api/users/3
        [HttpGet("{id}")]

        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            return await _db.Users.FindAsync(id);
        }

    }
}
