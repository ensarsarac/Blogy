using Blogy.DTOLayer.SocialMediaDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.SocialMediaValidator
{
	public class CreateSocialMediaValidator:AbstractValidator<CreateSocialMediaDto>
	{
        public CreateSocialMediaValidator()
        {
            RuleFor(x => x.Platform).NotEmpty().WithMessage("Platform adı boş bırakılamaz.");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Icon boş bırakılamaz.");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Url adı boş bırakılamaz.");
        }
    }
}
