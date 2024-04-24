using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Writer.ViewComponents
{
    public class _WriterLayoutSideBarComponent:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;

        public _WriterLayoutSideBarComponent(UserManager<AppUser> userManager, IArticleService articleService)
        {
            _userManager = userManager;
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userImage = user.ImageUrl;
            ViewBag.userNameSurname = user.Name+" "+user.Surname;
            ViewBag.articleCount = _articleService.TGetArticleListByUserId(user.Id).Count();
            return View(); 
        }
    }
}
