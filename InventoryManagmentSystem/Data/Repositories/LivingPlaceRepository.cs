using InventoryManagmentSystem.Data.Models;
using InventoryManagmentSystem.Data.Models.DTOs.LivingPlace;
using InventoryManagmentSystem.Data.Interfaces;

namespace InventoryManagmentSystem.Data.Repositories
{
    public class LivingPlaceRepository : ILivingPlaceRepository
    {
        private readonly InventoryManagmentDbContext _dbContext;
        private readonly IUserInformationRepository _userInfoRepo;

        public LivingPlaceRepository(InventoryManagmentDbContext dbContext, IUserInformationRepository userInfoRepo)
        {
            _dbContext = dbContext;
            _userInfoRepo = userInfoRepo;
        }

        private UserInformation? GetUserInformation(Guid userId)
        {
            return _userInfoRepo.GetUserDetails(userId);
        }

        public List<LivingPlace> GetAllLivingPlaces()
        {
            return _dbContext.LivingPlaces.ToList();
        }

        public LivingPlace? GetLivingPlace(Guid userId)
        {
            var livingPlaceId = GetUserInformation(userId).LivingPlaceInformationId;
            return _dbContext.LivingPlaces.Where(x => x.Id == livingPlaceId).FirstOrDefault();
        }

        public LivingPlace? UpdateLivingPlace(Guid userId, UpdateLivingPlaceDto userInfoDto)
        {
            var livingPlace = GetLivingPlace(userId);
            if (livingPlace is null)
                return null;

            livingPlace.City = userInfoDto.City;
            livingPlace.Street = userInfoDto.Street;
            livingPlace.HouseNumber = userInfoDto.HouseNumber;
            livingPlace.FlatNumber = userInfoDto.FlatNumber;

            _dbContext.SaveChanges();
            return livingPlace;
        }
    }
}
