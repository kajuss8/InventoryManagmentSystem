using InventoryManagmentSystem.Data.Interfaces;
using InventoryManagmentSystem.Data.Models;
using InventoryManagmentSystem.Data.Models.DTOs.UserInformation;

namespace InventoryManagmentSystem.Data.Repositories
{
    public class UserInformationRepository : IUserInformationRepository
    {
        private readonly InventoryManagmentDbContext _dbContext;
        private readonly IUserRepository _userRepo;

        public UserInformationRepository(InventoryManagmentDbContext dbContext, IUserRepository userRepo)
        {
            _dbContext = dbContext;
            _userRepo = userRepo;
        }

        private User? GetUser(Guid userId)
        {
            return _userRepo.GetUser(userId);
        }

        public List<UserInformation> GetAllUserDetails()
        {
            return _dbContext.UsersInformation!.ToList();
        }

        public UserInformation? GetUserDetails(Guid userId)
        {
            var infoId = GetUser(userId)?.InformationId;
            return _dbContext.UsersInformation.Where(x => x.Id == infoId).FirstOrDefault();
        }

        public async Task<UserInformation> UpdateUserInformation(Guid userId, UpdateUserInfoDto userInfoDto)
        {
            var userInfo = GetUserDetails(userId);
            if (userInfo is null)
            {
                return null;
            }

            userInfo.Name = userInfoDto.Name;
            userInfo.Surname = userInfoDto.Surname;
            userInfo.PhoneNumber = userInfoDto.PhoneNumber;
            userInfo.Email = userInfoDto.Email;

            await _dbContext.SaveChangesAsync();
            return userInfo;
        }
    }
}
