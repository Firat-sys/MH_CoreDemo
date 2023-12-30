using BusinessLayer.Concrete;
using BusinessLayer.EntityFramework;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MH_CoreDemo.Controllers
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
    }


    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            List<City> CityViewModel = new List<City> {
            new City { CityId = 1, CityName = "Adana" },
            new City { CityId = 2, CityName = "Ağrı" },
            new City { CityId = 3, CityName = "Bursa" },
            new City {CityId = 3, CityName = "Bursa" },
            new City { CityId = 4, CityName = "Diyarbakır" },
            new City { CityId = 5, CityName = "Gaziantep" },
            new City { CityId = 6, CityName = "İzmir" },
            new City { CityId = 7, CityName = "İstanbul" },
            new City { CityId = 8, CityName = "Muğla" },
            new City { CityId = 9, CityName = "Muş" },
            new City { CityId = 10, CityName = "Urfa" },
            new City { CityId = 11, CityName = "Zonguldağ" }
            };

            //{ new City { CityId=1, CityName="jkn"}};
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult result = wv.Validate(writer);
            if (result.IsValid)
            {
                writer.WriterAbout = "Deneme test";
                writer.WriterStatus = true;
                wm.TAdd(writer);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
