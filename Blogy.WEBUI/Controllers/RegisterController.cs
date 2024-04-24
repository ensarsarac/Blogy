using AutoMapper.Internal;
using Blogy.BusinessLayer.ValidationRules.AppUserValidator;
using Blogy.DTOLayer.AppUserDtos;
using Blogy.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using MimeKit.Text;
using MimeKit;

namespace Blogy.WEBUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegisterAppUserDto model)
        {
            RegisterAppUserValidation validationRules = new RegisterAppUserValidation();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                    AppUser user = new AppUser()
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        Email = model.Email,
                        UserName = model.UserName,
                        ImageUrl = "default-image.jpg",
                    };
                    var createResult = await _userManager.CreateAsync(user, model.Password);
                    if (createResult.Succeeded)
                    {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var link = Url.Action("ConfirmEmail","Register", new { email=user.Email,token }, Request.Scheme);
                    bool response = SendConfirmEmail(user.Email,link);
                    if (response)
                    {
                        await _userManager.AddToRoleAsync(user, "Writer");
                        return RedirectToAction("CheckEmail");
                    }
                    
                    }
                    else
                    {
                        foreach (var item in createResult.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(model);
        }
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return View("Error");

            var result = await _userManager.ConfirmEmailAsync(user, token);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }
        public IActionResult CheckEmail()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public bool SendConfirmEmail(string userEmail, string link)
        {
            var email = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "ensar.src94@gmail.com");
            email.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User",userEmail);
            email.To.Add(mailboxAddressTo);

            email.Subject = "Email Doğrulama";
            email.Body = new TextPart(TextFormat.Html) { Text = link };

            var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("ensar.src94@gmail.com", "iqqm qtvq xqkp kndf");
            try
            {
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
    }
}
