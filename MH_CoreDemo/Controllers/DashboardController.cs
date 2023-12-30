using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MH_CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            using var c = new Context();
            var UserName = User.Identity.Name;
            ViewBag.v = UserName;
            var userMail = c.Users.Where(x => x.UserName == UserName).Select(y => y.Email).FirstOrDefault();
            var writeId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterId == writeId).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}
