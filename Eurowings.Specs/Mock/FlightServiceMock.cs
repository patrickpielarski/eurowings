using System.Text.Json;
using System.Text.Json.Serialization;
using Eurowings.Model;
using Eurowings.Services;
using Eurowings.Specs.Properties;

namespace Eurowings.Specs.Mock;
internal class FlightServiceMock : IFlightService
{
    public Task<IEnumerable<Flight>> GetAllFlightsAsync()
    {
        var expectedFlights = JsonSerializer.Deserialize<IEnumerable<Flight>>(Resources.TestData, new JsonSerializerOptions
                                  { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } }) ??
                              Enumerable.Empty<Flight>();
        return Task.FromResult(expectedFlights);
    }

    public Task<IEnumerable<Flight>> GetAllFlightsByCriteriaAsync(string? from, string? to, string? airline)
    {
        var query = JsonSerializer.Deserialize<IEnumerable<Flight>>(Resources.TestData, new JsonSerializerOptions
                                  { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } }) ??
                              Enumerable.Empty<Flight>().AsQueryable();

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

        return Task.FromResult(query.AsEnumerable());
    }
}
