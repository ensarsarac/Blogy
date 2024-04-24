using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Writer.ViewComponents
{
    public class _WriterLayoutNavbarComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
