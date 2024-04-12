using Blogy.DTOLayer.AboutDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.AboutValidator
{
	public class UpdateAboutDtoValidator:AbstractValidator<UpdateAboutDto>
	{
		public UpdateAboutDtoValidator()
		{
			RuleFor(x => x.Title1).NotEmpty().WithMessage("Başlık 1 alanı boş bırakılamaz.");
			RuleFor(x => x.ImageUrl1).NotEmpty().WithMessage("Görsel 1 alanı boş bırakılamaz.");
			RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Görsel 2 alanı boş bırakılamaz.");
			RuleFor(x => x.Title2).NotEmpty().WithMessage("Başlık 2 alanı boş bırakılamaz.");
			RuleFor(x => x.Description1).NotEmpty().WithMessage("Açıklama 1 alanı boş bırakılamaz.");
			RuleFor(x => x.Description1).MinimumLength(50).WithMessage("Açıklama 1 alanı en az 50 karakter olmalı.");
			RuleFor(x => x.Description2).MinimumLength(50).WithMessage("Açıklama 2 alanı en az 50 karakter olmalı.");
			RuleFor(x => x.Description2).NotEmpty().WithMessage("Açıklama 2 alanı boş bırakılamaz.");
		}
	}
}
