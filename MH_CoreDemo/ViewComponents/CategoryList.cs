using BusinessLayer.Concrete;
using BusinessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MH_CoreDemo.ViewComponents
{
    public class CategoryList:ViewComponent
    {
        CategoryManager cm = new CategoryManager( new EFCategoryRepository());

        public IViewComponentResult Invoke()
        {
            var value = cm.GetListAll();
            return View(value);
        }
    }
}
