using Blogy.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.CategoryValidator
{
    public class UpdateCategoryValidation:AbstractValidator<Category>
    {
        public UpdateCategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Kategori Adını Boş Geçmeyiniz.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen Kategori Adını En Az 3 Karakter Olarak Giriniz.");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Lütfen Kategori Adını En Fazla 30 Karakter Olarak Giriniz.");
        }
    }
}
