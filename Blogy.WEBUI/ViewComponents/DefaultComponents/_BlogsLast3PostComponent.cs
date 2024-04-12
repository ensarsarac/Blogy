using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.ArticleDtos;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.ViewComponents.DefaultComponents
{
    public class _BlogsLast3PostComponent:ViewComponent
    {
        private readonly IArticleService _articleService;

        public _BlogsLast3PostComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TLastPostList();
            var result = values.Select(x => new Last3BlogDto()
            {
                CreatedDate=x.CreatedDate,
                ArticleID=x.ArticleID,
                CoverImageUrl=x.CoverImageUrl,
                Title=x.Title,
            }).ToList();
            return View(result);
        }
    }
}
