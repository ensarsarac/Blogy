using Blogy.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.ArticleValidator
{
    public class CreateArticleValidator:AbstractValidator<Article>
    {
        public CreateArticleValidator()
        {
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Lütfen makale için bir kategori seçiniz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen makale için bir başlık seçiniz");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen başlığa için en az 5 karakter veri girişi yapınız. ");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Lütfen başlığa için en fazla 100 karakter veri girişi yapınız. ");
        }
    }
}
