using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MH_CoreDemo.Models
{
    public class UserSingInViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanucı ismini doldurun")]
        public string username { get; set; }
        [Required(ErrorMessage = "Lütfen şifre kısmını doldurun")]
        public string password { get; set; }
    }
}
