using BusinessLayer.Concrete;
using BusinessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MH_CoreDemo.ViewComponents.Comment
{
    public class CommentListByBlog: ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.id = id;
            var value = cm.GetListAll(id);

            if (value.Count==0)
            {
                ViewBag.ErrorMessage = "  Bu bloğa yorum yapılmamıştır ";
                return View(value);
            }

            return View(value);
        }
    }
}
