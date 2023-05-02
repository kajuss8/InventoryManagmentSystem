using System.ComponentModel.DataAnnotations;

namespace InventoryManagmentSystem.Data.Models.DTOs.LivingPlace
{
    public class UpdateLivingPlaceDto
    {
        [StringLength(20, MinimumLength = 1)]
        public string City { get; set; }
        [StringLength(20, MinimumLength = 1)]
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int FlatNumber { get; set; }
    }
}
