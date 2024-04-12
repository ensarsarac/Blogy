using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstract
{
    public interface IArticleDal:IGenericDal<Article>
    {
        List<Article> GetBlogListWithCategoryAndUser();
        List<Article> GetBlogListWithCategory();
        List<Article> CategoryTechnologyLast3Article();
        List<Article> CategorySporLast3Article();
        List<Article> CategoryGameLast3Article();
        List<Article> CategoryFilmLast3Article();
        List<Article> CategoryHealthLast3Article();
        List<Article> LastPostList();
        Article GetArticleByIdWithCategoryAndUser(int id);
    }
}
