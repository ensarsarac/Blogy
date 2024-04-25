using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.MessageDtos;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MyMessagesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;

        public MyMessagesController(UserManager<AppUser> userManager, IMessageService messageService)
        {
            _userManager = userManager;
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _messageService.TGetMessageListByUserId(user.Id);
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
        public IActionResult DeleteMessage(int id)
        {
            _messageService.TRemove(id);
            return RedirectToAction("Index");
        }
    }
}
