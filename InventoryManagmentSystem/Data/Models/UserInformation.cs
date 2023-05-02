using AutoMapper.Configuration.Annotations;
using InventoryManagmentSystem.Data.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagmentSystem.Data.Models
{
    public class UserInformation
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte[] ProfileImage { get; set; }

        public Guid? LivingPlaceInformationId { get; set; }
        public LivingPlace? LivingPlace { get; set; }
    }
}
