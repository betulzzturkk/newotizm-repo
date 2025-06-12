using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AutismEducationPlatform.Web.Models.ViewModels;
using AutismEducationPlatform.Web.Models;
using System.Threading.Tasks;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AutismEducationPlatform.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber
                };

                if (model.Role == "Parent")
                {
                    user.ChildName = model.ChildName;
                    user.ChildAge = model.ChildAge;
                }
                else if (model.Role == "Instructor")
                {
                    user.Specialization = model.Specialization;
                }

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    if (model.Role == "Parent")
                        return RedirectToAction("Index", "Parent");
                    else if (model.Role == "Instructor")
                        return RedirectToAction("Dashboard", "Instructor");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles.Contains("Parent"))
                        return RedirectToAction("Index", "Parent");
                    else if (roles.Contains("Instructor"))
                        return RedirectToAction("Dashboard", "Instructor");
                    else if (roles.Contains("Admin"))
                        return RedirectToAction("Index", "Admin");
                }

                ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private string GenerateAvatarUrl(string name, string surname)
        {
            var fullName = $"{name} {surname}";
            var encodedName = HttpUtility.UrlEncode(fullName);
            var colors = new[] { "FF6B6B", "4ECDC4", "45B7D1", "96CEB4", "FFEEAD", "D4A5A5", "9B59B6", "3498DB", "1ABC9C", "F1C40F" };
            var randomColor = colors[new Random().Next(colors.Length)];
            
            return $"https://ui-avatars.com/api/?name={encodedName}&background={randomColor}&color=fff&size=256";
        }
    }
} 