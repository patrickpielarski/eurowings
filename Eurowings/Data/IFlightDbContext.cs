using Eurowings.Model;
using Microsoft.EntityFrameworkCore;

namespace Eurowings.Data;

public interface IFlightDbContext
{
    public DbSet<Flight> Flights { get; set; }
}
