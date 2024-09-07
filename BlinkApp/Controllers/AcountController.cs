using BlinkApp.Models;
using BlinkApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlinkApp.Controllers
{
    public class AcountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AcountController(UserManager<AppUser> _userManeger, SignInManager<AppUser> _signInManager,RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManeger;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = new AppUser()
            {
                Name = rvm.Name,
                Surname = rvm.Surname,
                Age = rvm.Age,
                Email = rvm.Email,
                UserName = rvm.Email.Split('@')[0],
            };
            var result = await userManager.CreateAsync(appUser, rvm.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(rvm);
            }
            await signInManager.SignInAsync(appUser, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult LockIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LockIn(LoginViewModel lvm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser logginguser = await userManager.FindByEmailAsync(lvm.Email);
            if (logginguser == null)
            {
                ModelState.AddModelError("", "Email or password is wrong!");
                return View(lvm);
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await signInManager.PasswordSignInAsync(logginguser, lvm.Password, lvm.StayLogedIn, true);
            if (!signInResult.Succeeded)
            {
                if (signInResult.IsLockedOut)
                {
                    ModelState.AddModelError("", "You are Lock out,Please try again after 30 minutes");
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is wrong!");
                }
                return View(lvm);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Lockout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        //public async Task<IActionResult> CreateRoles()
        //{
        //    await roleManager.CreateAsync(new IdentityRole() { Name = "admin" });
        //    await roleManager.CreateAsync(new IdentityRole() { Name="member" });
        //    return Content("Ok");
        //}
    }
}
