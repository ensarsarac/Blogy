using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.DTOLayer.CategoryDtos;
using Blogy.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework
{
	public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        private readonly BlogyContext _context;
        public EfCategoryRepository(BlogyContext context) : base(context)
        {
            _context = context;
        }

        public List<CategoryNameAndCountDto> GetAllCategoriesAndCount()
        {
            var values = _context.Articles.GroupBy(x => x.CategoryID).Select(y => new CategoryNameAndCountDto()
            {
                CategoryID = y.Key,
                Name=_context.Categories.Where(x=>x.CategoryID==y.Key).Select(z=>z.Name).FirstOrDefault(),
                Count=y.Count(),
            }).ToList();
            return values;
        }

		public List<Article> GetCategoryListById(int id)
		{
            var values = _context.Articles.Where(x => x.CategoryID == id).Include(y => y.Category).OrderByDescending(x=>x.CreatedDate).ToList();
            return values;
		}
	}
}
