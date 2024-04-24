using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Writer.ViewComponents
{
    public class _WriterLayoutHeadComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
