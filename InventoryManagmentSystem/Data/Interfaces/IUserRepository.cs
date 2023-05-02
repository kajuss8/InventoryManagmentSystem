using InventoryManagmentSystem.Data.Models;

namespace InventoryManagmentSystem.Data.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User user, IFormFile imgae);
        User? GetUser(Guid id);
        User? GetUser(string username);
        Task DeleteUser(User user);
    }
}
