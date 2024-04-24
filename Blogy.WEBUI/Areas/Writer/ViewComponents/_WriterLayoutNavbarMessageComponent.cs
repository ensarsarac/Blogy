using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.MessageDtos;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Writer.ViewComponents
{
    public class _WriterLayoutNavbarMessageComponent:ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public _WriterLayoutNavbarMessageComponent(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _messageService.TGetLast3MessageListByUserId(user.Id);
            ViewBag.messagecount = _messageService.TGetMessageListByUserId(user.Id).Count();
            var result = values.Select(x => new GetMessatListDto()
            {
                Date = x.Date,
                Detail=x.Detail,
                MessageId = x.MessageId,
                SenderUserImageUrl = x.SenderUser.ImageUrl,
                SenderUserName = x.SenderUser.UserName,
                Subject = x.Subject
            }).ToList();
            return View(result);
        }
    }
}
