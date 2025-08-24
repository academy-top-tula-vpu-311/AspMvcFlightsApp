using Microsoft.AspNetCore.Mvc;
using AspMvcFlightsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AspMvcFlightsApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AirportController : Controller
    {
        DataModelDbContext dataContext;

        public AirportController(DataModelDbContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var airports = dataContext.Airports
                                      .Include(a => a.City)
                                      .ToList();

            return View(airports);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var cities = dataContext?.Cities?.ToList();
            cities?.Insert(0, new() { Id = 0, Title = "" });
            ViewBag.Cities = cities;

            return View();
        }

        [HttpPost]
        public IActionResult Create(AirportData airport)
        {
            if(airport is not null)
            {
                if(airport.CityId == 0)
                {
                    airport.CityId = null;
                    airport.City = null;
                }
                dataContext.Airports.Add(airport);
                dataContext.SaveChanges();
                return RedirectToAction("Index");

            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id is not null)
            {
                AirportData? airport = dataContext?.Airports
                                                  .FirstOrDefault(a => a.Id == id);
                if(airport is not null)
                {
                    var cities = dataContext?.Cities?.ToList();
                    cities?.Insert(0, new() { Id = 0, Title = "" });
                    ViewBag.Cities = cities;
                    return View(airport);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(AirportData airport)
        {
            if (airport.CityId == 0)
            {
                airport.CityId = null;
                airport.City = null;
            }
            dataContext.Airports?.Update(airport);
            dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id is not null)
            {
                AirportData? airport = dataContext?.Airports
                                                  .FirstOrDefault(a => a.Id == id);
                if(airport is not null)
                {
                    dataContext?.Airports?.Remove(airport);
                    dataContext?.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return NotFound();
        }
    }
}
