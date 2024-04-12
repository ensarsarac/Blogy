using Blogy.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.CategoryValidator
{
    public class CreateCategoryValidation:AbstractValidator<Category>
    {
        public CreateCategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Kategori Adını En Az 3 Karakter Olarak Giriniz.");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Kategori Adını En Fazla 30 Karakter Olarak Giriniz.");
        }
    }
}
