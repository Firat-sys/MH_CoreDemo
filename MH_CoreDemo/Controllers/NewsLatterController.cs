using BusinessLayer.Concrete;
using BusinessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MH_CoreDemo.Controllers
{
    public class NewsLatterController : Controller
    {
        NewsLatterManager nm = new NewsLatterManager(new EfNewsLatterRepository());

        [HttpGet]
        public IActionResult SubScribeMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubScribeMail(NewsLatter p)
        {
           p.MailStatus = true;
            nm.AddnewsLatter(p);
           // Response.Redirect("/NewsLatter/SubScribeMail/" + 1);
            return RedirectToAction("Index","Blog");
        }
    }
}
