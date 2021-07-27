using DoctorManagement.Controllers;
using DoctorManagement.Controllers.DTOs;
using DoctorManagement.Data;
using DoctorManagement.Interfaces;
using DoctorManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoctorManagement.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ApplicationDbContext _db;
        private readonly ITokenService _tokenService;

        public AccountController(ApplicationDbContext db, ITokenService tokenService)
        {
            _db = db;
            _tokenService = tokenService;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Doctors>>> showRegs()
        {
            return await _db.Users.ToListAsync();
        }



        [HttpPost("register")]

        public async Task<ActionResult<UserDto>> Register(RegisterDto regDto)
        {
            using var hmac = new HMACSHA512();

            if (await UserExists(regDto.Username))
            {
                return BadRequest("Username is not unique");
            }

            var user = new Doctors
            {
                DoctorName = regDto.DoctorName,
                HospitalName = regDto.HospitalName,
                Designation = regDto.Designation,
                Username = regDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(regDto.Password)),
                PasswordSalt = hmac.Key

            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return new UserDto
            {
                Username = user.Username,
                Token = _tokenService.addToken(user)

            };
        }

        [HttpPost("login")]

        public async Task<ActionResult<UserDto>> Login(LoginDto logDto)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Username == logDto.Username);

            if (user == null)
            {
                return Unauthorized("Invalid Username");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(logDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                    return Unauthorized("Invalid Password");
            }

            return new UserDto
            {
                Username = user.Username,
                Token = _tokenService.addToken(user)

            };

        }

        private async Task<bool> UserExists(string username)
        {
            return await _db.Users.AnyAsync(x => x.Username == username.ToLower());

        }



    }
}
