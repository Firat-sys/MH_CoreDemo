using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("kategori ismini boş geçemzsin");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("kategori açıklamasını boş geçemzsin");
            RuleFor(x => x.CategoryName).MaximumLength(150).WithMessage("kategori ismini en fazla 150 karakterden oluşabilir");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("kategori ismini en az iki karakterli olmalıdır");
        }
    }
}
