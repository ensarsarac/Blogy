using Blogy.BusinessLayer.ValidationRules.AppUserValidator;
using Blogy.DTOLayer.AppUserDtos;
using Blogy.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

		public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}
		public IActionResult Index()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginAppUserDto model)
        {
			LoginViewModelValidator validator = new LoginViewModelValidator();
			ValidationResult resultValidator = validator.Validate(model);
			if(resultValidator.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);
				var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, true);
				if(result.Succeeded)
				{
					return RedirectToAction("Index", "Default");
				}
				if (result.IsLockedOut)
				{
                    ModelState.AddModelError("", "Çok fazla yanlış girdiniz. Belirli süre bloke oldunuz.");
                }
				else
				{
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                }
            }
            else
            {

                foreach (var item in resultValidator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index");
        }


    }
}
