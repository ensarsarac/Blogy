using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blogy.WEBUI.ViewComponents.DefaultComponents
{
    public class _CommentListComponent:ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentListComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke()
        {
            
            return View(new CreateCommentDto());
        }
    }
}
