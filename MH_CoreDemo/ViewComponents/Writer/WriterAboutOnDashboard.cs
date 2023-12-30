using BusinessLayer.Concrete;
using BusinessLayer.EntityFramework;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MH_CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            var UserName = User.Identity.Name;
           
            var userMail = c.Users.Where(x => x.UserName == UserName).Select(y => y.Email).FirstOrDefault();
           var WriterId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.v = WriterId;

            ViewBag.v2 = WriterId;
            var values = wm.GetWriterById(WriterId);
            return View(values);
        }
    }
}
