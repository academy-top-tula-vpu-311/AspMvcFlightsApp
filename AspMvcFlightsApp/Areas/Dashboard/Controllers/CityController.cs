using AspMvcFlightsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspMvcFlightsApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CityController : Controller
    {
        DataModelDbContext dataContext;

        public CityController(DataModelDbContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IActionResult Index()
        {
            return View(dataContext?.Cities?.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(CityData city)
        {
            if(ModelState.IsValid)
            {
                dataContext?.Cities?.Add(city);
                dataContext?.SaveChanges();
                return RedirectToAction("Index");
                
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id is not null)
            {
                CityData? city = dataContext?.Cities?
                                            .FirstOrDefault(c => c.Id == id);
                if(city is not null)
                    return View(city);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(CityData city)
        {
            dataContext?.Cities?.Update(city);
            dataContext?.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id is not null)
            {
                CityData? city = dataContext?.Cities?
                                            .FirstOrDefault(c => c.Id == id);
                if (city is not null)
                {
                    dataContext?.Cities?.Remove(city);
                    dataContext?.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return NotFound();
        }

    }
}
