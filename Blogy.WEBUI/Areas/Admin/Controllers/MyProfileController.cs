using Blogy.BusinessLayer.ValidationRules.AppUserValidator;
using Blogy.DTOLayer.AppUserDtos;
using Blogy.EntityLayer.Concrete;
using Blogy.WEBUI.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MyProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            EditProfileViewModel model = new EditProfileViewModel();
            model.Surname = values.Surname;
            model.Name = values.Name;
            model.Email = values.Email;
            model.UserName = values.UserName;
            model.Image = values.ImageUrl;
            model.Description = values.Description;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(EditProfileViewModel model)
        {
            EditProfileViewModelValidation validationRules = new EditProfileViewModelValidation();
            ValidationResult result = validationRules.Validate(model);
            if (result.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (model.ImageUrl != null)
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var imagename = Guid.NewGuid() + extension;
                    var savelocation = resource + "/wwwroot/UserImage/" + imagename;
                    var stream = new FileStream(savelocation, FileMode.Create);

                    await model.ImageUrl.CopyToAsync(stream);
                    user.ImageUrl = imagename;
                }
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.Description = model.Description;
                if (model.Password != null)
                {
                    if (model.Password == model.ConfirmPassword)
                    {
                        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Şifreler Uyuşmuyor");
                    }
                }
                var loginResult = await _userManager.UpdateAsync(user);
                if (loginResult.Succeeded)
                {
                    return RedirectToAction("LogOut", "Login", new { @area = "" });
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
    }
}
