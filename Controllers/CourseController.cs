using Microsoft.AspNetCore.Mvc;
using AutismEducationPlatform.Web.Data;
using AutismEducationPlatform.Web.Models;
using AutismEducationPlatform.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AutismEducationPlatform.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CourseController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var courses = new List<Course>
            {
                new Course { Id = 1, Name = "HAYVANLAR", Description = "Hayvanları tanıyalım", ImageUrl = "/images/courses/animals.jpg", Category = "Temel Eğitim" },
                new Course { Id = 2, Name = "RENKLER", Description = "Renkleri öğrenelim", ImageUrl = "/images/courses/colors.jpg", Category = "Temel Eğitim" },
                new Course { Id = 3, Name = "ŞEKİLLER", Description = "Şekilleri keşfedelim", ImageUrl = "/images/courses/shapes.jpg", Category = "Temel Eğitim" },
                new Course { Id = 4, Name = "SAYILAR", Description = "Sayıları öğrenelim", ImageUrl = "/images/courses/numbers.jpg", Category = "Matematik" },
                new Course { Id = 5, Name = "HİKAYELER", Description = "Hikayeler dinleyelim", ImageUrl = "/images/courses/tales.jpg", Category = "Dil Gelişimi" },
                new Course { Id = 6, Name = "TRAFİK İŞARETLERİ", Description = "Trafik işaretlerini öğrenelim", ImageUrl = "/images/courses/traffic.jpg", Category = "Güvenlik" },
                new Course { Id = 7, Name = "GÖRGÜ KURALLARI", Description = "Görgü kurallarını öğrenelim", ImageUrl = "/images/courses/manners.jpg", Category = "Sosyal Beceriler" },
                new Course { Id = 8, Name = "EĞİTİM VİDEOLARI", Description = "Eğitici videolar izleyelim", ImageUrl = "/images/courses/videos.jpg", Category = "Multimedya" }
            };

            return View(courses);
        }

        public IActionResult Animals()
        {
            var animals = new List<AnimalViewModel>
            {
                new AnimalViewModel
                {
                    Id = 1,
                    Name = "Kedi",
                    Description = "Miyav!",
                    ImagePath = "/images/animals/cat.jpg",
                    SoundPath = "/sounds/animals/kedi.mp3"
                },
                new AnimalViewModel
                {
                    Id = 2,
                    Name = "Köpek",
                    Description = "Hav hav!",
                    ImagePath = "/images/animals/dog.jpg",
                    SoundPath = "/sounds/animals/kopek.mp3"
                },
                new AnimalViewModel
                {
                    Id = 3,
                    Name = "İnek",
                    Description = "Möö!",
                    ImagePath = "/images/animals/cow.jpg",
                    SoundPath = "/sounds/animals/inek.mp3"
                },
                new AnimalViewModel
                {
                    Id = 4,
                    Name = "Kuş",
                    Description = "Cik cik!",
                    ImagePath = "/images/animals/bird.jpg",
                    SoundPath = "/sounds/animals/kus.mp3"
                },
                new AnimalViewModel
                {
                    Id = 5,
                    Name = "At",
                    Description = "Nayy!",
                    ImagePath = "/images/animals/horse.jpg",
                    SoundPath = "/sounds/animals/at.mp3"
                },
                new AnimalViewModel
                {
                    Id = 6,
                    Name = "Fil",
                    Description = "Puuuuh!",
                    ImagePath = "/images/animals/elephant.jpg",
                    SoundPath = "/sounds/animals/fil.mp3"
                },
                new AnimalViewModel
                {
                    Id = 7,
                    Name = "Aslan",
                    Description = "Kükreeme!",
                    ImagePath = "/images/animals/lion.jpg",
                    SoundPath = "/sounds/animals/aslan.mp3"
                },
                new AnimalViewModel
                {
                    Id = 8,
                    Name = "Tavuk",
                    Description = "Gıt gıt gıdak!",
                    ImagePath = "/images/animals/chicken.jpg",
                    SoundPath = "/sounds/animals/tavuk.mp3"
                }
            };

            // Kullanıcı giriş yapmışsa, ilerleme bilgilerini getir
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var progresses = _context.AnimalProgress
                    .Where(p => p.UserId == userId)
                    .ToDictionary(p => p.AnimalId, p => p.ProgressValue);

                // Her hayvan için ilerleme bilgisini ekle
                foreach (var animal in animals)
                {
                    if (progresses.ContainsKey(animal.Id))
                    {
                        animal.Progress = progresses[animal.Id];
                    }
                }
            }

            return View(animals);
        }

        public IActionResult Colors() => View();
        public IActionResult Shapes() => View();
        public IActionResult Numbers() => View();
        public IActionResult Tales() => View();
        public IActionResult TrafficSigns() => View();
        public IActionResult Manners() => View();
        public IActionResult EducationalVideos() => View();

        public IActionResult Details(int id)
        {
            switch (id)
            {
                case 1:
                    return RedirectToAction("Animals");
                case 2:
                    return RedirectToAction("Colors");
                case 3:
                    return RedirectToAction("Numbers");
                case 4:
                    return RedirectToAction("Shapes");
                case 5:
                    return RedirectToAction("Tales");
                case 6:
                    return RedirectToAction("TrafficSigns");
                case 7:
                    return RedirectToAction("Manners");
                case 8:
                    return RedirectToAction("EducationalVideos");
                default:
                    return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAnimalProgress(int animalId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, message = "Lütfen giriş yapın.", requireLogin = true });
            }

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var progress = await _context.AnimalProgress
                    .FirstOrDefaultAsync(p => p.AnimalId == animalId && p.UserId == userId);

                if (progress == null)
                {
                    progress = new AnimalProgress
                    {
                        AnimalId = animalId,
                        UserId = userId,
                        ProgressValue = 0,
                        InteractionCount = 0,
                        LastInteraction = DateTime.UtcNow
                    };
                    _context.AnimalProgress.Add(progress);
                }

                progress.InteractionCount++;
                progress.LastInteraction = DateTime.UtcNow;
                
                // Her tıklamada %20 artır, maksimum %100
                progress.ProgressValue = Math.Min(100, progress.ProgressValue + 20);

                await _context.SaveChangesAsync();

                return Json(new { success = true, progress = progress.ProgressValue });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}