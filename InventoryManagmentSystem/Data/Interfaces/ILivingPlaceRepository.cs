using InventoryManagmentSystem.Data.Models.DTOs.LivingPlace;
using InventoryManagmentSystem.Data.Models;

namespace InventoryManagmentSystem.Data.Interfaces
{
    public interface ILivingPlaceRepository
    {
        List<LivingPlace> GetAllLivingPlaces();
        LivingPlace? GetLivingPlace(Guid userId);
        LivingPlace UpdateLivingPlace(Guid userId, UpdateLivingPlaceDto userInfoDto);
    }
}
