using AutomationTravelAgency.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AutomationTravelAgency.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Booking> Booking { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Models.Domain.Route> Route { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }


    }
}
