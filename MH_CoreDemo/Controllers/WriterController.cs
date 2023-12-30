using BusinessLayer.Concrete;
using BusinessLayer.EntityFramework;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using MH_CoreDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MH_CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        WriterManager wm = new WriterManager(new EfWriterRepository());
        //UserManager userManager = new UserManager(new EfAppUserRepository());

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            using var c = new Context();
            var UserName = User.Identity.Name;
            ViewBag.v1 = UserName; var Writename = c.Writers.Where(x => x.WriterMail == UserName).Select(x => x.WriterName).FirstOrDefault();
            ViewBag.v2 = Writename;
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        // [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {

            //using var c = new Context();
            //var UserName = User.Identity.Name;
            //var writerMail = c.Users.Where(x => x.UserName == UserName).Select(y => y.Email).FirstOrDefault();
            ////var WriterId = c.Writers.Where(x => x.WriterMail == writerMail).Select(x => x.WriterId).FirstOrDefault();
            ////var WriterValues = wm.TGetById(WriterId);
            ////return View(WriterValues);
            //var id = c.Users.Where(x => x.Email == writerMail).Select(y => y.Id).FirstOrDefault();
            ////var result = await _userManager.FindByNameAsync(User.Identity.Name);
            //var values = userManager.TGetById(id);
            //return View(values);

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel userUpdate = new UserUpdateViewModel();
            userUpdate.mail = values.Email;
            userUpdate.nameuser = values.NameUser;
            userUpdate.imageurl = values.ImageUrl;
            userUpdate.username = values.UserName;
            return View(userUpdate);
        }
        // [AllowAnonymous]
        [HttpPost]
        // public IActionResult WriterEditProfile(AppUser user, string confirmPassword)
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel userUpdate)
        {
            // userManager.TUpdate(user);
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = userUpdate.mail;
            values.NameUser = userUpdate.nameuser;
            values.ImageUrl=userUpdate.imageurl;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, userUpdate.password);
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
       
            //WriterValidator wl = new WriterValidator();
            //ValidationResult results = wl.Validate(w);

            //if (!string.Equals(w.PasswordHash, confirmPassword))
            //{
            //    ModelState.AddModelError("ConfirmPassword", "Şifreler eşleşmiyor.");
            //}

            //if (results.IsValid && ModelState.IsValid)
            //{
            //    wm.TUpdate(w);
            //    return RedirectToAction("Index", "Dashboard");
            //}
            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}

            //return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImg p)
        {
            Writer w = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterAbout = p.WriterAbout;
            // w.WriterId = p.WriterId;
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.ConfirmPassword = p.ConfirmPassword;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }

    }
}

