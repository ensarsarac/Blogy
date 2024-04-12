using Blogy.DTOLayer.CategoryDtos;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        List<CategoryNameAndCountDto> GetAllCategoriesAndCount();
        List<Article> GetCategoryListById(int id);
    }
}
