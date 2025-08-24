namespace AspMvcFlightsApp.Models
{
    public class FlightData
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? AirlineId { get; set; }
        public AirlineData? Airline { get; set; }

        public int? DepartureId { get; set; }
        public AirportData? Departure { get; set; }

        public int? ArrivalId { get; set; }
        public AirportData? Arrival { get; set; }

        public DateTime DateTime { get; set; }
    }
}
