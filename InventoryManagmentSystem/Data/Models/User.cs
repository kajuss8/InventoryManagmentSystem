using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace InventoryManagmentSystem.Data.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }

        public Guid? InformationId { get; set; }
        public UserInformation? UserInformation { get; set; }
    }
}
