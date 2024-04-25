using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.ArticleDtos;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Writer.ViewComponents
{
    public class _DashboardMyBlogsComponent:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;

        public _DashboardMyBlogsComponent(UserManager<AppUser> userManager, IArticleService articleService)
        {
            _userManager = userManager;
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticleListByUserId(user.Id);
            var result = values.Select(x => new GetArticleByUserIdDto
            {
                ArticleId=x.ArticleID,
                CategoryName=x.Category.Name,
                Date=x.CreatedDate,
                NameSurname=x.AppUser.Name+" "+x.AppUser.Surname,
                Title=x.Title,
                UserImageUrl=x.AppUser.ImageUrl,
                
            }).ToList();
            return View(result);
        }
    }
}
