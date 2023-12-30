using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MH_CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistik2:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new Context();

            ViewBag.v1 = c.Blogs.OrderByDescending(x => x.BlogId).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();

            return View();
        }
    }
}
