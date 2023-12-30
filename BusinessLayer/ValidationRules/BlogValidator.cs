using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Bloğun başlığını boş geçemezsin!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Bloğun içeriğini boş geçemezsin!");
            RuleFor(x => x.BlogImg).NotEmpty().WithMessage("Bloğun resmini boş geçemezsin!");
            RuleFor(x => x.BlogContent).MinimumLength(5).WithMessage("Blok içeriği 5 karakterden fazla olmalı.");
            RuleFor(x => x.BlogContent).MaximumLength(300).WithMessage("Blok içeriği 300 karakterden az olmalı.");
        }
    }
}
