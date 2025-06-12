using Microsoft.EntityFrameworkCore;
using AutismEducationPlatform.Web.Models;

namespace AutismEducationPlatform.Web.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Courses.Any())
                {
                    return;
                }

                context.Courses.AddRange(
                    new Course
                    {
                        Name = "Hayvanları Tanıyalım",
                        Description = "Çocukların hayvanları tanımasını sağlayan eğlenceli bir kurs",
                        Category = "Hayvanlar",
                        DifficultyLevel = 3,
                        ImageUrl = "/images/courses/animals.jpg",
                        DurationMinutes = 30
                    },
                    new Course
                    {
                        Name = "Renkleri Öğreniyorum",
                        Description = "Temel renkleri öğreten interaktif aktiviteler",
                        Category = "Renkler",
                        DifficultyLevel = 2,
                        ImageUrl = "/images/courses/colors.png",
                        DurationMinutes = 25
                    },
                    new Course
                    {
                        Name = "Sayıları Keşfedelim",
                        Description = "1'den 10'a kadar sayıları öğreten eğlenceli oyunlar",
                        Category = "Sayılar",
                        DifficultyLevel = 4,
                        ImageUrl = "/images/courses/numbers.jpg",
                        DurationMinutes = 35
                    },
                    new Course
                    {
                        Name = "Şekilleri Öğrenelim",
                        Description = "Temel geometrik şekilleri tanıtan eğlenceli aktiviteler",
                        Category = "Şekiller",
                        DifficultyLevel = 2,
                        ImageUrl = "/images/courses/shapes.jpg",
                        DurationMinutes = 25
                    },
                    new Course
                    {
                        Name = "Duygularımız",
                        Description = "Temel duyguları tanıma ve ifade etme aktiviteleri",
                        Category = "Duygular",
                        DifficultyLevel = 3,
                        ImageUrl = "/images/courses/emotions.jpg",
                        DurationMinutes = 30
                    },
                    new Course
                    {
                        Name = "Trafik İşaretlerini Öğrenelim",
                        Description = "Temel trafik işaretlerini ve anlamlarını öğreten eğitici içerik",
                        Category = "Trafik",
                        DifficultyLevel = 4,
                        ImageUrl = "/images/courses/traffic.jpg",
                        DurationMinutes = 40
                    },
                    new Course
                    {
                        Name = "Görgü Kuralları",
                        Description = "Temel görgü kurallarını öğreten interaktif aktiviteler",
                        Category = "Görgü Kuralları",
                        DifficultyLevel = 3,
                        ImageUrl = "/images/courses/manners.jpg",
                        DurationMinutes = 35
                    },
                    new Course
                    {
                        Name = "Eğitici Masallar",
                        Description = "Öğretici ve eğlenceli masallar koleksiyonu",
                        Category = "Masallar",
                        DifficultyLevel = 2,
                        ImageUrl = "/images/courses/stories.jpg",
                        DurationMinutes = 45
                    },
                    new Course
                    {
                        Name = "Eğitici Videolar",
                        Description = "Çeşitli konularda eğitici video içerikleri",
                        Category = "Videolar",
                        DifficultyLevel = 1,
                        ImageUrl = "/images/courses/videos.jpg",
                        DurationMinutes = 50
                    }
                );

                context.SaveChanges();
            }
        }
    }
} 