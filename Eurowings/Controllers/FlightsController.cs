using Eurowings.Model;
using Eurowings.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eurowings.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightsController(IFlightService flightService)
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Flight>>> GetAllFlightsAsync()
    {
        var flights = await flightService.GetAllFlightsAsync();
        return Ok(flights);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Flight>>> GetAllFlightsByCriteriaAsync(string? from = null, string? to = null, string? airline = null)
    {
        if (!string.IsNullOrEmpty(from) && from.Length != 3)
            return BadRequest("Airport Code must be 3 letters");

        if (!string.IsNullOrEmpty(to) && to.Length != 3)
            return BadRequest("Airport Code must be 3 letters");

        if (!string.IsNullOrEmpty(airline) && airline.Length > 50)
            return BadRequest("Airline Code must be less or equal 50 letters");

        var flights = await flightService.GetAllFlightsByCriteriaAsync(from, to, airline);
        return Ok(flights);
    }
}
