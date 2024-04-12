using Blogy.DTOLayer.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.AppUserValidator
{
    public class LoginViewModelValidator:AbstractValidator<LoginAppUserDto>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş bırakılamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen email formatına uygun giriniz");
        }
    }
}
