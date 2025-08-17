using System.ComponentModel.DataAnnotations;

namespace AspMvcFlightsApp.Models
{
    public class AirportData
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название аэропорта обязательно")]
        public string Title { get; set; } = null!;

        public int? CityId { get; set; }
        public CityData? City { get; set; }
    }
}
