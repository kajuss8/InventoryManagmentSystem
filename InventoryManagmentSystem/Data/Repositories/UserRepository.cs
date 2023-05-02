using InventoryManagmentSystem.Data;
using InventoryManagmentSystem.Data.Interfaces;
using InventoryManagmentSystem.Data.Models;

namespace InventoryManagmentSystem.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly InventoryManagmentDbContext _dbContext;

        public UserRepository(InventoryManagmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private byte[] ChangeImageToBytes(IFormFile image)
        {
            using var memoryStream = new MemoryStream();
            image.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        public User? GetUser(Guid id)
        {
            return _dbContext.Users?.Where(x => x.Id == id).FirstOrDefault();
        }

        public User? GetUser(string username)
        {
            return _dbContext.Users?.Where(x => x.UserName.Equals(username)).FirstOrDefault();
        }

        public Task CreateUser(User user, IFormFile image)
        {
            var livingPlace = new LivingPlace()
            {
                Id = new Guid(),
                City = string.Empty,
                Street = string.Empty,
                HouseNumber = 0,
                FlatNumber = 0
            };
            _dbContext.LivingPlaces.Add(livingPlace);
            _dbContext.SaveChanges();

            var userInformation = new UserInformation()
            {
                Id = new Guid(),
                Name = string.Empty,
                Surname = string.Empty,
                Email = string.Empty,
                ProfileImage = ChangeImageToBytes(image)
            };
            userInformation.LivingPlaceInformationId = livingPlace.Id;
            userInformation.LivingPlace = livingPlace;

            _dbContext.UsersInformation?.Add(userInformation);
            _dbContext.SaveChanges();

            user.InformationId = userInformation.Id;
            user.UserInformation = userInformation;

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task DeleteUser(User user)
        {
            var userInfoId = user.InformationId;
            var userInfo = _dbContext.UsersInformation.FirstOrDefault(u => u.Id == userInfoId);
            var livingPlaceid = userInfo.LivingPlaceInformationId;
            var livingPlace = _dbContext.LivingPlaces.FirstOrDefault(l => l.Id == livingPlaceid);

            _dbContext.Users.Remove(user);
            _dbContext.UsersInformation.Remove(userInfo);
            _dbContext.LivingPlaces.Remove(livingPlace);
            _dbContext.SaveChanges();
            
            return Task.CompletedTask;
        }
    }
}
