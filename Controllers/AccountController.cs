using DatingApp.Controllers.DTOs;
using DatingApp.Data;
using DatingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ApplicationDbContext _db;

        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Users>>> showRegs()
        {
            return await _db.Users.ToListAsync();
        }
        

        
        [HttpPost("register")]

        public async Task<ActionResult<Users>> Register(RegisterDto regDto)
        {
            using var hmac = new HMACSHA512();

            if(await UserExists(regDto.Username))
            {
                return BadRequest("Username is not unique");
            }

            var user = new Users
            {
                Username = regDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(regDto.Password)),
                PasswordSalt = hmac.Key
            
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return user;
        }

        private async Task<bool> UserExists(string username)
        {
            return await _db.Users.AnyAsync(x => x.Username == username.ToLower());

        }



    }
}
