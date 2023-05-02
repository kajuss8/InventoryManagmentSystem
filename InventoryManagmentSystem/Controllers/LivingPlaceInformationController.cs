using InventoryManagmentSystem.Data;
using InventoryManagmentSystem.Data.Interfaces;
using InventoryManagmentSystem.Data.Models;
using InventoryManagmentSystem.Data.Models.DTOs.LivingPlace;
using InventoryManagmentSystem.Data.Models.DTOs.UserInformation;
using InventoryManagmentSystem.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace InventoryManagmentSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LivingPlaceInformationController : ControllerBase
    {
        private readonly ILivingPlaceRepository _livingPlaceRepo;
        private readonly IUserRepository _userRepo;

        private User? GetUser()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _userRepo.GetUser(Guid.Parse(id));
        }

        public LivingPlaceInformationController(ILivingPlaceRepository repo, IUserRepository userRepo)
        {
            _livingPlaceRepo = repo;
            _userRepo = userRepo;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<LivingPlace>>> GetAll()
        {
            return await Task.FromResult(_livingPlaceRepo.GetAllLivingPlaces());
        }

        [HttpGet]
        public async Task<ActionResult<LivingPlace>> Get()
        {
            var user = GetUser();
            if (user is null)
                return Unauthorized();

            var livingPlace = await Task.FromResult(_livingPlaceRepo.GetLivingPlace(user.Id));
            if (livingPlace == null)
            {
                return NotFound();
            }
            return livingPlace;
        }

        [HttpPut]
        public async Task<ActionResult<LivingPlace>> Put(UpdateLivingPlaceDto updateUserInfoDto)
        {
            var user = GetUser();
            if (user is null)
                return Unauthorized();

            var updatedInfo = _livingPlaceRepo.UpdateLivingPlace(user.Id, updateUserInfoDto);
            return updatedInfo;
        }
    }
}
