using InventoryManagmentSystem.Data;
using InventoryManagmentSystem.Data.Attributes;
using InventoryManagmentSystem.Data.Interfaces;
using InventoryManagmentSystem.Data.Models;
using InventoryManagmentSystem.Data.Models.DTOs.UserInformation;
using InventoryManagmentSystem.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Security.Claims;

namespace InventoryManagmentSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserInformationController : ControllerBase
    {
        private readonly IUserInformationRepository _userInfoRepo;
        private readonly IUserRepository _userRepo;

        private User? GetUser()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _userRepo.GetUser(Guid.Parse(id));
        }

        public UserInformationController(IUserInformationRepository repo, IUserRepository userRepo)
        {
            _userInfoRepo = repo;
            _userRepo = userRepo;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<UserInformation>>> GetAll()
        {
            return await Task.FromResult(_userInfoRepo.GetAllUserDetails());
        }

        [HttpGet]
        public async Task<ActionResult<UserInformation>> Get()
        {
            var user = GetUser();
            if (user is null)
                return Unauthorized();

            var userInformation = await Task.FromResult(_userInfoRepo.GetUserDetails(user.Id));
            if (userInformation == null)
            {
                return NotFound();
            }
            return userInformation;
        }

        [HttpPut]
        public async Task<ActionResult<UserInformation>> Put(UpdateUserInfoDto updateUserInfoDto)
        {
            var user = GetUser();
            if (user is null)
                return Unauthorized();

            var updatedInfo = await _userInfoRepo.UpdateUserInformation(user.Id, updateUserInfoDto);
            return await Task.FromResult(updatedInfo);
        }
    }
}
