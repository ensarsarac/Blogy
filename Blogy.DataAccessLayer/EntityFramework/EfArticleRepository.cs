using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework
{
    public class EfArticleRepository:GenericRepository<Article>,IArticleDal
    {
        private readonly BlogyContext _context;

        public EfArticleRepository(BlogyContext context):base(context)
        {
            _context = context;
        }

		public List<Article> CategoryFilmLast3Article()
		{
			var values = _context.Articles.Where(x => x.CategoryID == (_context.Categories.Where(y => y.Name == "Sinema Film").Select(y => y.CategoryID).FirstOrDefault())).Include(z => z.AppUser).Include(z => z.Category).OrderByDescending(x => x.CreatedDate).Take(3).ToList();

			return values;
		}

		public List<Article> CategoryGameLast3Article()
		{
			var values = _context.Articles.Where(x => x.CategoryID == (_context.Categories.Where(y => y.Name == "Oyun").Select(y => y.CategoryID).FirstOrDefault())).Include(z => z.AppUser).Include(z => z.Category).OrderByDescending(x => x.CreatedDate).Take(3).ToList();

			return values;
		}

		public List<Article> CategoryHealthLast3Article()
		{
			var values = _context.Articles.Where(x => x.CategoryID == (_context.Categories.Where(y => y.Name == "Sağlık").Select(y => y.CategoryID).FirstOrDefault())).Include(z => z.AppUser).Include(z => z.Category).OrderByDescending(x => x.CreatedDate).Take(3).ToList();

			return values;
		}

		public List<Article> CategorySporLast3Article()
        {
            var values = _context.Articles.Where(x => x.CategoryID == (_context.Categories.Where(y => y.Name == "Spor").Select(y => y.CategoryID).FirstOrDefault())).Include(z => z.AppUser).Include(z => z.Category).OrderByDescending(x => x.CreatedDate).Take(3).ToList();

            return values;
        }

        public List<Article> CategoryTechnologyLast3Article()
		{
            var values = _context.Articles.Where(x => x.CategoryID == (_context.Categories.Where(y => y.Name == "Teknoloji").Select(y => y.CategoryID).FirstOrDefault())).Include(z=>z.AppUser).Include(z=>z.Category).OrderByDescending(x=>x.CreatedDate).Take(3).ToList();

            return values;
		}

        public Article GetArticleByIdWithCategoryAndUser(int id)
        {
            var values = _context.Articles.Where(x=>x.ArticleID==id).Include(x=>x.AppUser).Include(x=>x.Category).FirstOrDefault();
            return values;
        }

        public List<Article> GetBlogListWithCategory()
        {
            var values = _context.Articles.Include(x => x.Category).OrderByDescending(x=>x.CreatedDate).ToList();
            return values;
        }

        public List<Article> GetBlogListWithCategoryAndUser()
        {
            var values = _context.Articles.Include(x=>x.Category).Include(y=>y.AppUser).OrderByDescending(x=>x.ArticleID).ToList();
            return values;
        }

        public List<Article> LastPostList()
        {
            var values = _context.Articles.OrderByDescending(x=>x.CreatedDate).Take(3).ToList();
            return values;
        }
    }
}
