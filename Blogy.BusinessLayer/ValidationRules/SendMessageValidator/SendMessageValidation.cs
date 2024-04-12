using Blogy.DTOLayer.SendMessageDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.SendMessageValidator
{
	public class SendMessageValidation:AbstractValidator<SendMessageDto>
	{
        public SendMessageValidation()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad soyad alanı boş bırakılamaz.");
            RuleFor(x => x.NameSurname).MinimumLength(3).WithMessage("Ad soyad alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.NameSurname).MaximumLength(50).WithMessage("Ad soyad alanı en fazla 50 karakter olmalıdır.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş bırakılamaz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email formatına uygun değil.");

			RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş bırakılamaz.");
			RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu alanı en az 3 karakter olmalıdır.");
			RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu alanı en fazla 50 karakter olmalıdır.");

			RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj alanı boş bırakılamaz.");
			RuleFor(x => x.Message).MinimumLength(25).WithMessage("Mesaj alanı en az 25 karakter olmalıdır.");
			RuleFor(x => x.Message).MaximumLength(250).WithMessage("Konu alanı en fazla 250 karakter olmalıdır.");
		}
    }
}
