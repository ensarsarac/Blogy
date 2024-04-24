using Blogy.DTOLayer.ForgetPasswordDtos;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace Blogy.WEBUI.Controllers
{
    [AllowAnonymous]
    public class ForgetPasswordController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ForgetPasswordController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ForgetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ResetPassword", "ForgetPassword", new
            {
                userId = user.Id,
                token = passwordResetToken,
            }, HttpContext.Request.Scheme);

            var email = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "ensar.src94@gmail.com");
            email.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.Email);
            email.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordResetTokenLink;
            email.Subject = "Şifre Değişiklik Talebi";
            email.Body = bodyBuilder.ToMessageBody();

            var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("ensar.src94@gmail.com", "iqqm qtvq xqkp kndf");
            smtp.Send(email);
            smtp.Disconnect(true);
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userid, string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];

            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }

    }
}
