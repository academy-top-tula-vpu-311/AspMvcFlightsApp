using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AspMvcFlightsApp.Models
{
    public class CityData
    {
        public int Id { get; set; }

        [Display(Name = "Название города")]
        [Required(ErrorMessage = "Название города обязательно!")]
        [Remote(action: "CheckTitle",
                controller: "City",
                areaName: "Dashboard",
                ErrorMessage = "Такой город уже есть")]
        [DataType(DataType.Text)]
        public string Title { get; set; } = null!;
    }
}
