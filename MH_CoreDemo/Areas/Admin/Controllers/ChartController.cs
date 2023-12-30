using MH_CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MH_CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass{
              categoryname="Teknoloji", 
                categoycount=10  
            });
            list.Add(new CategoryClass
            {
                categoryname = "Spor",
                categoycount = 14
            });
            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categoycount = 5
            });
            list.Add(new CategoryClass
            {
                categoryname = "Sinema",
                categoycount = 2
            });
            return Json(new { jsonlist = list });
        }
    }
}
