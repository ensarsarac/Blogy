using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Admin.ViewComponents
{
    public class _AdminFooterComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
