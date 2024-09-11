using Eurowings.Model;
using Microsoft.EntityFrameworkCore;

namespace Eurowings.Data;

public class FlightDbContext(DbContextOptions<FlightDbContext> options) : DbContext(options), IFlightDbContext
{
    public DbSet<Flight> Flights { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>().ToTable("Flight");
        modelBuilder.Entity<Flight>()
            .HasKey(f => f.FlightId);

        modelBuilder.Entity<Flight>()
            .Property(f => f.OriginStation)
            .HasMaxLength(3)
            .IsRequired();

        modelBuilder.Entity<Flight>()
            .Property(f => f.DestinationStation)
            .HasMaxLength(3)
            .IsRequired();

        modelBuilder.Entity<Flight>()
            .Property(f => f.AirlineCode)
            .HasMaxLength(50);
    }
}
