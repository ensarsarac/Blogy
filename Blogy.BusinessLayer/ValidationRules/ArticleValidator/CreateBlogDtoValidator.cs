using Blogy.DTOLayer.BlogDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.ArticleValidator
{
    public class CreateBlogDtoValidator:AbstractValidator<CreateBlogDto>
    {
        public CreateBlogDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş bırakılamaz.");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Başlık en 3 karakter veri girişi olmalıdır.");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Başlık en 100 karakter veri girişi olmalıdır.");

            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik alanı boş bırakılamaz.");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Kategori alanı boş bırakılamaz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel alanı boş bırakılamaz.");


        }
    }
}
