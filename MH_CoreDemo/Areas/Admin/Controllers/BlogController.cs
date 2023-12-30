using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using MH_CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MH_CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
      
        public IActionResult ExportStaticExecelBlogList()
        {
            using (var WorkBook = new XLWorkbook())
            {
                var workSheet = WorkBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog Id";
                workSheet.Cell(1, 2).Value = "Blog Adı";
                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    workSheet.Cell(BlogRowCount, 1).Value = item.Id;
                    workSheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var streem=new MemoryStream())
                {
                    WorkBook.SaveAs(streem);
                    var content = streem.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheedml.sheed","Çalışma1.xlsx");
                }
            }
            //return View();
        }
        List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{Id=1 ,BlogName="C# programlamaya giriş"},
                 new BlogModel{Id=2, BlogName="Tesla nın Araçları"},
                  new BlogModel{Id =3, BlogName ="C# programlamaya giriş"}
            };
            return bm;
        }
        public IActionResult BlogListExel()
        {
            return View();
        }

       public IActionResult ExportDynamicExecelBlogList()
        {
            using (var WorkBook = new XLWorkbook())
            {
                var workSheet = WorkBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog Id";
                workSheet.Cell(1, 2).Value = "Blog Adı";
                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    workSheet.Cell(BlogRowCount, 1).Value = item.Id;
                    workSheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var streem = new MemoryStream())
                {
                    WorkBook.SaveAs(streem);
                    var content = streem.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheedml.sheed", "Çalışma1.xlsx");
                }
            }
            //return View();
        }

       public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> bm = new List<BlogModel2>();

            using (var c=new Context())
            {
                bm = c.Blogs.Select(x => new BlogModel2
                { Id=x.BlogId, BlogName=x.BlogTitle
                }).ToList();
            }
            return bm;
        }
        public IActionResult BlogTitleExel()
        {
            return View();
        }
    }
}
