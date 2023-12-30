using BusinessLayer.Concrete;
using BusinessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MH_CoreDemo.ViewComponents.Writer
{
    public class WriterNatification:ViewComponent
    {
        NatificationManager nm = new NatificationManager(new EfNatificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = nm.GetListAll();
            return View(values);
        }
    }
}
