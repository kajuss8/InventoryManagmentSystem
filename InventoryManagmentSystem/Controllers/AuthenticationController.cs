using AutoMapper;
using InventoryManagmentSystem.Data.Interfaces;
using InventoryManagmentSystem.Data.Models;
using InventoryManagmentSystem.Data.Models.DTOs.User;
using InventoryManagmentSystem.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace InventoryManagmentSystem.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _repo;

        public AuthenticationController(IConfiguration configuration, IUserRepository repo)
        {
            _configuration = configuration;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm]RegisterDto registerModel)
        {
            if (_repo.GetUser(registerModel.UserName) is not null)
            {
                return BadRequest("User already exists");
            }

            CreatePasswordHash(registerModel.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User
            {
                Id = Guid.NewGuid(),
                UserName = registerModel.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "User",
            };

            await _repo.CreateUser(user, registerModel.ProfileImage);

            return Ok("User successfully created!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginModel)
        {
            var user = _repo.GetUser(loginModel.UserName);

            if (user is null)
            {
                return BadRequest("User not found.");
            }

            if (!VerifyPasswordHash(loginModel.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("User name or password is invalid");
            }

            string token = CreateToken(user);
            return Ok(token);
        }

        [HttpDelete("delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userDelete = _repo.GetUser(id);
            if (userDelete is null)
            {
                return BadRequest("User not found");
            }

            _repo.DeleteUser(userDelete);
            return Ok("User successfully Deleted!");
        }

        private string CreateToken(User account)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.UserName!),
                new Claim(ClaimTypes.Role, account.Role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Secret").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }
}
