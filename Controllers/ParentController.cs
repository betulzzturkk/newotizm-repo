using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using AutismEducationPlatform.Web.Models;
using AutismEducationPlatform.Web.Models.ViewModels;
using AutismEducationPlatform.Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AutismEducationPlatform.Web.Controllers
{
    [Authorize(Roles = "Parent")]
    public class ParentController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ParentController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new ParentProfileViewModel
            {
                FirstName = user.FirstName ?? string.Empty,
                LastName = user.LastName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber ?? string.Empty,
                ChildName = user.ChildName ?? string.Empty,
                ChildAge = user.ChildAge ?? 0
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new ParentProfileViewModel
            {
                FirstName = user.FirstName ?? string.Empty,
                LastName = user.LastName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber ?? string.Empty,
                ChildName = user.ChildName ?? string.Empty,
                ChildAge = user.ChildAge ?? 0
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(ParentProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.ChildName = model.ChildName;
            user.ChildAge = model.ChildAge;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        public IActionResult Activities()
        {
            return View();
        }

        public IActionResult Progress()
        {
            return View();
        }

        public IActionResult Messages()
        {
            return View();
        }
    }
} 