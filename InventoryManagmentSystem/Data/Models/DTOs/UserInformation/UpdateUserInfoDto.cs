using System.ComponentModel.DataAnnotations;

namespace InventoryManagmentSystem.Data.Models.DTOs.UserInformation
{
    public class UpdateUserInfoDto
    {
        [StringLength(20 ,MinimumLength = 1)]
        public string Name { get; set; }
        [StringLength(20, MinimumLength = 1)]
        public string Surname { get; set; }
        public int PhoneNumber { get; set; }
        [StringLength(30, MinimumLength = 1)]
        public string Email { get; set; }
    }
}
