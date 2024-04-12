using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstract
{
    public interface IArticleService:IGenericService<Article>
    {
        List<Article> TGetBlogListWithCategoryAndUser();
        List<Article> TGetBlogListWithCategory();
        List<Article> TCategoryTechnologyLast3Article();
        List<Article> TCategorySporLast3Article();
        List<Article> TCategoryGameLast3Article();
        List<Article> TCategoryFilmLast3Article();
        List<Article> TCategoryHealthLast3Article();
        List<Article> TLastPostList();
        Article TGetArticleByIdWithCategoryAndUser(int id);
    }
}
