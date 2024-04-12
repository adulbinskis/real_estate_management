using BuildingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }
        public DbSet<Building>? Buildings { get; set; }
        public DbSet<Apartment>? Apartments { get; set; }
        public DbSet<Tenant>? Tenants { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>()
                .HasIndex(t => t.PersonalCode)
                .IsUnique();

        }
    }
}
