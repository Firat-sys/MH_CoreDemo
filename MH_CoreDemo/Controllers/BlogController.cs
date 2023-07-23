using BusinessLayer.Concrete;
using BusinessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MH_CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var list = bm.GetBlogListWithCategory();
            return View(list);
        }
        public IActionResult BlogReadAll(int Id=0)
        {


            //   var values = bm.BlogGetById(Id);
            ViewBag.i = Id;
            var values = bm.GetBlogById(Id);
          
            return View(values);
        }
    }
}
