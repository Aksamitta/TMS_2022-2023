using Lab24_Aksana.Patrubeika_EFComponents.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab24_Aksana.Patrubeika_EFComponents.Data
{
    public class AirLineContext : DbContext
    {
        public AirLineContext()
        {
        }

        public AirLineContext(DbContextOptions<AirLineContext> options)
            : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PassInTrip> PassInTrips { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=USER-PC;Initial Catalog=Lab24_AirLine;Integrated Security=True;TrustServerCertificate=True");

    }
}
