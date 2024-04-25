using Blogy.DataAccessLayer.Context;
using Blogy.WEBUI.Areas.Writer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class GoogleChartController : Controller
    {
        private readonly BlogyContext _context;

        public GoogleChartController(BlogyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Chart()
        {
            var values = _context.Articles.GroupBy(x => x.CategoryID).Select(y => new ChartViewModel
            {
                name = _context.Categories.Where(x => x.CategoryID == y.Key).Select(x => x.Name).FirstOrDefault(),
                count = y.Count(),
            }).ToList();
            return Json(new {jsonlist=values});
        }
        
    }
}
