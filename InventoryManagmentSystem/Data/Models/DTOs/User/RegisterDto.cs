using InventoryManagmentSystem.Data.Attributes;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagmentSystem.Data.Models.DTOs.User
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Name can't be shorter than 4 and longer than 15 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(15, MinimumLength = 4 ,ErrorMessage = "Password can't be shorter than 4 and longer than 15 characters")]
        public string Password { get; set; }
        [MaxFileSize(200*200)]
        [AllowedExtension(new string[] { ".png", ".jpg" })]
        [Required(ErrorMessage = "Imgae is required")]
        public IFormFile ProfileImage { get; set; }
    }
}
