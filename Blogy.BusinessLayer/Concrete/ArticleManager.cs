using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public void TAdd(Article entity)
        {
            _articleDal.Insert(entity);
        }

		public List<Article> TCategoryFilmLast3Article()
		{
            return _articleDal.CategoryFilmLast3Article();
		}

		public List<Article> TCategoryGameLast3Article()
		{
			return _articleDal.CategoryGameLast3Article();
		}

		public List<Article> TCategoryHealthLast3Article()
		{
			return _articleDal.CategoryHealthLast3Article();
		}

		public List<Article> TCategorySporLast3Article()
        {
            return _articleDal.CategorySporLast3Article();
        }

        public List<Article> TCategoryTechnologyLast3Article()
		{
			return _articleDal.CategoryTechnologyLast3Article();
		}

		public List<Article> TGetAllList()
        {
            return _articleDal.GetListAll();
        }

        public Article TGetArticleByIdWithCategoryAndUser(int id)
        {
            return _articleDal.GetArticleByIdWithCategoryAndUser(id);
        }

        public List<Article> TGetBlogListWithCategory()
        {
            return _articleDal.GetBlogListWithCategory();
        }

        public List<Article> TGetBlogListWithCategoryAndUser()
        {
            return _articleDal.GetBlogListWithCategoryAndUser();
        }

		

		public Article TGetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public List<Article> TLastPostList()
        {
            return _articleDal.LastPostList();
        }

        public void TRemove(int id)
        {
            _articleDal.Remove(id);
        }

        public void TUpdate(Article entity)
        {
            _articleDal.Update(entity);
        }
    }
}
