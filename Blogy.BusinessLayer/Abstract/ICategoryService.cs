using Blogy.DTOLayer.CategoryDtos;
using Blogy.EntityLayer.Concrete;

namespace Blogy.BusinessLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        List<CategoryNameAndCountDto> TGetAllCategoriesAndCount();
        List<Article> TGetCategoryListById(int id);
    }
}
