using Blogy.DTOLayer.SocialMediaDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.SocialMediaValidator
{
	public class UpdateSocialMediaValidator:AbstractValidator<UpdateSocialMediaDto>
	{
		public UpdateSocialMediaValidator()
		{
			RuleFor(x => x.Platform).NotEmpty().WithMessage("Platform adı boş bırakılamaz.");
			RuleFor(x => x.Icon).NotEmpty().WithMessage("Icon boş bırakılamaz.");
			RuleFor(x => x.Url).NotEmpty().WithMessage("Url adı boş bırakılamaz.");
		}
	}
}
