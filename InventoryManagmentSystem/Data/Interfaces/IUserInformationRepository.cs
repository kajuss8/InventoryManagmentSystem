using InventoryManagmentSystem.Data.Models.DTOs.UserInformation;
using InventoryManagmentSystem.Data.Models;

namespace InventoryManagmentSystem.Data.Interfaces
{
    public interface IUserInformationRepository
    {
        List<UserInformation> GetAllUserDetails();
        UserInformation? GetUserDetails(Guid userId);
        Task<UserInformation> UpdateUserInformation(Guid userId, UpdateUserInfoDto userInfoDto);
    }
}
