using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.DTOLayer.CategoryDtos;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TAdd(Category entity)
        {
            _categoryDal.Insert(entity);
        }

        public List<CategoryNameAndCountDto> TGetAllCategoriesAndCount()
        {
            return _categoryDal.GetAllCategoriesAndCount();
        }

        public List<Category> TGetAllList()
        {
            return _categoryDal.GetListAll();
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

		public List<Article> TGetCategoryListById(int id)
		{
            return _categoryDal.GetCategoryListById(id);
		}

		public void TRemove(int id)
        {
            _categoryDal.Remove(id);
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
