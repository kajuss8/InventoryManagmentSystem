using InventoryManagmentSystem.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagmentSystem.Data
{
    public class InventoryManagmentDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<UserInformation>? UsersInformation { get; set; }
        public DbSet<LivingPlace>? LivingPlaces { get; set; }

        public InventoryManagmentDbContext(DbContextOptions<InventoryManagmentDbContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
