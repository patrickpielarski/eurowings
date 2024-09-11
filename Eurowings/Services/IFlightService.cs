using Eurowings.Model;

namespace Eurowings.Services;

public interface IFlightService
{
    Task<IEnumerable<Flight>> GetAllFlightsAsync();
    Task<IEnumerable<Flight>> GetAllFlightsByCriteriaAsync(string? from, string? to, string? airline);
}