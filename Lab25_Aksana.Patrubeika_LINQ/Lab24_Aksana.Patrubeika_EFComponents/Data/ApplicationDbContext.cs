using Lab24_Aksana.Patrubeika_EFComponents.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab24_Aksana.Patrubeika_EFComponents.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PassInTrip> PassInTrips { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
    }
}