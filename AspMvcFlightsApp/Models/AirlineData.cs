using System.ComponentModel.DataAnnotations;

namespace AspMvcFlightsApp.Models
{
    public class AirlineData
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название авиалинии обязательно")]
        public string Title { get; set; } = null!;

        public string? Logo { get; set; }
        public int? CityId { get; set; }
        public CityData? City { get; set; }
    }
}
