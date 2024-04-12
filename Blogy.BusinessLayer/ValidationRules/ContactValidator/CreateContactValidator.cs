using Blogy.DTOLayer.ContactDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.ContactValidator
{
	public class CreateContactValidator:AbstractValidator<CreateContactDto>
	{
        public CreateContactValidator()
        {
            RuleFor(x => x.Location).NotEmpty().WithMessage("Lütfen lokasyon bilgisini doldurunuz.");
            RuleFor(x => x.OpenHours).NotEmpty().WithMessage("Lütfen çalışma saatleri bilgisini doldurunuz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen email formatına uygun giriniz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen email bilgisini doldurunuz.");
            RuleFor(x => x.Call).NotEmpty().WithMessage("Lütfen telefon numarası bilgisini doldurunuz.");
        }
    }
}
