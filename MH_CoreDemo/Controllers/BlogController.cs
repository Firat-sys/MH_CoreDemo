using BusinessLayer.Concrete;
using BusinessLayer.EntityFramework;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MH_CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfNatificationrepository());
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            var list = bm.GetBlogListWithCategory();
            return View(list);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int Id=0)
        {


            //   var values = bm.BlogGetById(Id);
            ViewBag.i = Id;
            var values = bm.GetBlogById(Id);
          
            return View(values);
        }
     
        public IActionResult BlogListByWriter()
        {
            using var c = new Context();
            var UserName = User.Identity.Name;
           // ViewBag.v = UserName;
            var userMail = c.Users.Where(x => x.UserName == UserName).Select(y => y.Email).FirstOrDefault();
            var WriterId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();

            //var WriterId = c.Writers.Where(x => x.WriterMail == UserName).Select(x => x.WriterId).FirstOrDefault();
            ViewBag.v = WriterId;
            var values = bm.GetListWithCategoryByWriterBM(WriterId);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = cm.GetListAll().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();

            ViewBag.cv = categoryValues;


            //List<SelectListItem> categoryvalues = (from x in cm.GetListAll()
            //                                       select new SelectListItem
            //                                       {

            //                                           Text = x.CategoryName,
            //                                           Value = x.CategoryId.ToString()
            //                                       }).ToList() ;
            //ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog b)
        {
            var UserName = User.Identity.Name;
            using var c = new Context();
            var WriterId = c.Writers.Where(x => x.WriterMail == UserName).Select(x => x.WriterId).FirstOrDefault();


            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(b);
            if (result.IsValid)
            {
                b.BlogStatus = true;
                b.WriterId=WriterId;
                b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                bm.TAdd(b);
                return RedirectToAction("BlogListByWriter", "blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
              return View();
            }

           
        }
        public IActionResult BlogDelete(int id)
        {
            var blogvalue = bm.BlogGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = bm.TGetById(id);

            List<SelectListItem> categoryvalues = (from x in cm.GetListAll()
                                                   select new SelectListItem
                                                   {

                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;

            return View(blogvalue);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult EditBlog(Blog b)
        {
            var UserName = User.Identity.Name;
            using var c = new Context();
            var WriterId = c.Writers.Where(x => x.WriterMail == UserName).Select(x => x.WriterId).FirstOrDefault();

            b.WriterId = WriterId;
            b.BlogStatus = true;
            b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            bm.TUpdate(b);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
