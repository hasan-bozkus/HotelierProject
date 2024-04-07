using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name = user.Name;
            userEditViewModel.Surname = user.Surname;
            userEditViewModel.UserName = user.UserName;
            userEditViewModel.Email = user.Email;
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = userEditViewModel.Name;
            user.Surname = userEditViewModel.Surname;
            user.UserName = userEditViewModel.UserName;
            user.Email = userEditViewModel.Email;
            if (userEditViewModel.Password != null)
            {
                if (userEditViewModel.Password == userEditViewModel.ConfirmPassword)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
                }
            }

            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Login");


        }
    }
}
