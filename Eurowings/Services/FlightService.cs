using Eurowings.Data;
using Eurowings.Model;
using Microsoft.EntityFrameworkCore;

namespace Eurowings.Services;

public class FlightService(IFlightDbContext context) : IFlightService
{
    public async Task<IEnumerable<Flight>> GetAllFlightsAsync()
    {
        return await context.Flights.ToListAsync();
    }

    public async Task<IEnumerable<Flight>> GetAllFlightsByCriteriaAsync(string? from, string? to, string? airline)
    {
        var query = context.Flights.AsQueryable();

        if (!string.IsNullOrEmpty(from))
        {
            query = query.Where(f => f.OriginStation == from);
        }

        if (!string.IsNullOrEmpty(to))
        {
            query = query.Where(f => f.DestinationStation == to);
        }

        if (!string.IsNullOrEmpty(airline))
        {
            query = query.Where(f => f.AirlineCode == airline);
        }

        return await query.AsNoTracking().ToListAsync();
    }
}