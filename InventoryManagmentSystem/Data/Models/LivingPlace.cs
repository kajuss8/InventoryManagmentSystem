using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagmentSystem.Data.Models
{
    public class LivingPlace
    {
        [Key]
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int FlatNumber { get; set; }
    }
}
