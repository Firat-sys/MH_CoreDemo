using BusinessLayer.Concrete;
using BusinessLayer.EntityFramework;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MH_CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {


        BlogManager bm = new BlogManager(new EfNatificationrepository());
      

        public IViewComponentResult Invoke()
        {
            using var c = new Context();

            ViewBag.v1 = bm.GetListAll().Count();
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();

            string api= "4fb10ebd50704e19f5e6325857ed4889";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=%C4%B0stanbul&mode=xml&appid="+api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
