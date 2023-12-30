using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MH_CoreDemo.Models
{
    public class UserSingUpViewModel
    {
        [Display (Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lütfen ad soyad girin")]
        public string NameUser { get; set; }
        
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifreyi girin")]
        public string Password { get; set; }

        [Display(Name = "Şifre tekrar")]
        [Compare("Password",ErrorMessage = "Şifre uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Lütfen Mailinizi girin")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adını girin")]
        public string UserName { get; set; }
    }
}
