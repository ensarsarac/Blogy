using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Admin.ViewComponents
{
    public class _AdminHeadComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
