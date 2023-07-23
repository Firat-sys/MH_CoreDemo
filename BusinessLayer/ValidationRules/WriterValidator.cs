using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("İsim kısmını boş geçemezin");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Maili boş geçemessin");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Bir isim en az iki karakterden oluşmalı");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Bir isim en fazla 50 karakterden oluşmalı");
            RuleFor(x => x.WriterPassword).Must(ContainUppercase).WithMessage("Şifrede en az bir büyük harf kullanılmalı");
            RuleFor(x => x.WriterPassword).Must(ContainLowercase).WithMessage("Şifrede en az bir küçük harf kullanılmalı");
            RuleFor(x => x.WriterPassword).Must(ContainDigit).WithMessage("Şifrede en az bir sayı kullanılmalı");
         
        }

        private bool ContainUppercase(string password)
        {
            return password.Any(char.IsUpper);
        }

        private bool ContainLowercase(string password)
        {
            return password.Any(char.IsLower);
        }

        private bool ContainDigit(string password)
        {
            return password.Any(char.IsDigit);
        }
    }
}

