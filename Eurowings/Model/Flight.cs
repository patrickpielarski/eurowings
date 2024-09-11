using System.ComponentModel.DataAnnotations;

namespace Eurowings.Model;

public class Flight
{
    [Key]
    public long FlightId { get; set; }
    [Required]
    public string OriginStation { get; set; }
    [Required]
    public string DestinationStation { get; set; }
    [Required]
    public DateTime FlightsAvailableFrom { get; set; }
    [Required]
    public DateTime FlightsAvailableTo { get; set; }

    public string? AirlineCode { get; set; }

}
