using Blogy.DTOLayer.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.AppUserValidator
{
    public class RegisterAppUserValidation:AbstractValidator<RegisterAppUserDto>
    {
        public RegisterAppUserValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş bırakılamaz.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Ad alanı en az 3 karakter veri girişi olmalıdır.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Ad alanı en fazla 50 karakter veri girişi olmalıdır.");


            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş bırakılamaz.");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Soyad alanı en az 3 karakter veri girişi olmalıdır.");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("Soyad alanı en fazla 50 karakter veri girişi olmalıdır.");


            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı alanı boş bırakılamaz.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı Adı alanı en az 3 karakter veri girişi olmalıdır.");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Kullanıcı Adı alanı en fazla 50 karakter veri girişi olmalıdır.");


            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş bırakılamaz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email formatında uygun giriniz.");


            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrar alanı boş bırakılamaz.");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Şifreler uyuşmuyor");

            RuleFor(x => x.Check).Must(x => x.Equals(true)).WithMessage("Lütfen şartları kabul ediniz.");

        }
    }
}
