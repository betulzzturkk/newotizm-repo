using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutismEducationPlatform.Web.Models;
using AutismEducationPlatform.Web.Models.ViewModels;
using AutismEducationPlatform.Web.Data;
using System.Security.Claims;

namespace AutismEducationPlatform.Web.Controllers
{
    [Authorize(Roles = "Instructor")]
    public class InstructorController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public InstructorController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Dashboard()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var instructor = await _userManager.FindByIdAsync(userId);

            if (instructor == null)
            {
                return NotFound();
            }

            var viewModel = new InstructorDashboardViewModel
            {
                InstructorInfo = new InstructorInfo
                {
                    Name = instructor.Name,
                    Email = instructor.Email ?? string.Empty,
                    PhoneNumber = instructor.PhoneNumber ?? string.Empty,
                    Specialization = instructor.Specialization ?? string.Empty,
                    Experience = "5+ years",
                    Education = "Master's in Special Education",
                    Certifications = "ABA Therapy, PECS",
                    Languages = "English, Turkish",
                    ProfilePicture = "/images/instructors/default.jpg",
                    TotalStudents = await _context.Users.CountAsync(u => u.InstructorId == userId),
                    ActiveCourses = await _context.Courses.CountAsync(c => c.InstructorId == userId && c.IsActive),
                    AverageRating = 4.5,
                    Expertise = "Autism Spectrum Disorders"
                },
                AssignedCourses = await _context.Courses
                    .Where(c => c.InstructorId == userId)
                    .Select(c => new CourseViewModel
                    {
                        Id = c.Id.ToString(),
                        Name = c.Name,
                        Description = c.Description,
                        Category = c.Category,
                        DifficultyLevel = c.DifficultyLevel,
                        DurationMinutes = c.DurationMinutes,
                        ImageUrl = c.ImageUrl ?? "/images/courses/default.jpg",
                        IsActive = c.IsActive
                    })
                    .ToListAsync(),
                Students = await _context.Users
                    .Where(u => u.InstructorId == userId)
                    .Select(s => new StudentInfo
                    {
                        Id = s.Id.ToString(), // düzeltme burada
                        Name = s.Name,
                        Age = 0,
                        ParentName = s.ParentName ?? string.Empty,
                        ParentContact = s.PhoneNumber ?? string.Empty,
                        Diagnosis = "Autism Spectrum Disorder",
                        ProgressStatus = "In Progress",
                        LastActivity = DateTime.UtcNow,
                        RecentActivities = new List<ActivityProgress>()
                    })
                    .ToListAsync(),
                Activities = await _context.Activities
                    .Where(a => a.Course.InstructorId == userId)
                    .Select(a => new ActivityProgress
                    {
                        ActivityId = a.Id,
                        ActivityName = a.Name,
                        CompletionDate = a.CompletionDate ?? DateTime.MinValue,
                        Score = a.Score,
                        IsCompleted = a.IsCompleted
                    })
                    .ToListAsync(),
                Announcements = await _context.Announcements
                    .Where(a => a.IsActive)
                    .OrderByDescending(a => a.Date)
                    .Select(a => new AnnouncementViewModel
                    {
                        Title = a.Title,
                        Content = a.Content,
                        Date = a.Date,
                        Type = a.Type,
                        IsRead = a.IsRead
                    })
                    .ToListAsync(),
                Messages = await _context.Messages
                    .Where(m => m.UserId == userId)
                    .OrderByDescending(m => m.Date)
                    .Select(m => new MessageViewModel
                    {
                        Title = m.Title,
                        Content = m.Content,
                        Date = m.Date,
                        SenderName = m.SenderName,
                        IsRead = m.IsRead
                    })
                    .ToListAsync(),
                UserProfile = new UserProfileViewModel
                {
                    Name = instructor.Name,
                    Email = instructor.Email ?? string.Empty,
                    PhoneNumber = instructor.PhoneNumber ?? string.Empty,
                    Role = "Instructor",
                    ProfilePicture = "/images/instructors/default.jpg",
                    IsActive = true,
                    LastLoginDate = instructor.LastLoginDate?.ToString() ?? string.Empty,
                    RegistrationDate = instructor.RegistrationDate.ToString(),
                    PreferredLanguage = "Turkish",
                    TimeZone = "Europe/Istanbul",
                    NotificationsEnabled = true
                }
            };

            return View(viewModel);
        }

        public IActionResult Courses() => View();

        public IActionResult Students() => View();

        public IActionResult Messages() => View();

        public IActionResult Profile() => View();

        public IActionResult AddCourse() => View(new CourseViewModel());

        [HttpPost]
        public IActionResult AddCourse(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Dashboard));
            }
            return View(model);
        }

        public IActionResult EditCourse(int id) => View();

        public IActionResult DeleteCourse(int id) => RedirectToAction(nameof(Dashboard));

        public IActionResult StudentList() => View();

        public IActionResult Information() => View();

        public IActionResult Feedback() => View();

        public override ViewResult View() => SetInstructorLayout(base.View());

        public override ViewResult View(object? model) => SetInstructorLayout(base.View(model));

        public override ViewResult View(string? viewName) => SetInstructorLayout(base.View(viewName));

        public override ViewResult View(string? viewName, object? model) => SetInstructorLayout(base.View(viewName, model));

        private ViewResult SetInstructorLayout(ViewResult view)
        {
            ViewData["Layout"] = "~/Views/Shared/_InstructorLayout.cshtml";
            return view;
        }
    }
}