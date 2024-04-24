using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Writer.ViewComponents
{
    public class _WriterLayoutFooterComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
