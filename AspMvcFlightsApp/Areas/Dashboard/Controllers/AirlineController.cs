using AspMvcFlightsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace AspMvcFlightsApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AirlineController : Controller
    {
        DataModelDbContext dataContext;
        public AirlineController(DataModelDbContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var airlines = dataContext.Airlines
                                      .Include(a => a.City)
                                      .ToList();
            return View(airlines);
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
        public IActionResult Create(AirlineData airline, IFormFile image)
        {
            if (airline is not null)
            {
                if (airline.CityId == 0)
                {
                    airline.CityId = null;
                    airline.City = null;
                }

                if (image is not null)
                {
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", ImageName);
                    using (var stream = new FileStream(SavePath, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }
                    airline.Logo = ImageName;
                }

                dataContext.Airlines.Add(airline);
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
                AirlineData? airline = dataContext.Airlines
                                                 .FirstOrDefault(a => a.Id == id);
                if(airline is not null)
                {
                    var cities = dataContext?.Cities?.ToList();
                    cities?.Insert(0, new() { Id = 0, Title = "" });
                    ViewBag.Cities = cities;

                    return View(airline);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(AirlineData airline)
        {
            if (airline.CityId == 0)
            {
                airline.CityId = null;
                airline.City = null;
            }

            dataContext.Airlines.Update(airline);
            dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id is not null)
            {
                AirlineData? airline = dataContext.Airlines
                                                 .FirstOrDefault(a => a.Id == id);
                if (airline is not null)
                {
                    dataContext.Airlines.Remove(airline);
                    dataContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return NotFound();
        }
    }
}
