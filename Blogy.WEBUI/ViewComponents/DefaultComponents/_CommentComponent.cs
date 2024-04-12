using Blogy.DTOLayer.CommentDtos;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.ViewComponents.DefaultComponents
{
    public class _CommentComponent:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            var value =new CreateCommentDto(){
                ArticleID = id,
            };
            return View(value);
        }
    }
}
