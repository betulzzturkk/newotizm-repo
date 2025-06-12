using System.ComponentModel.DataAnnotations;

namespace AutismEducationPlatform.Web.Models.ViewModels
{
    public class CourseViewModel
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public int DifficultyLevel { get; set; }

        public int DurationMinutes { get; set; }

        public int StudentCount { get; set; }

        public string Status { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kurs açıklaması gereklidir.")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kurs süresi gereklidir.")]
        [Display(Name = "Süre (dakika)")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Eğitmen seçimi gereklidir.")]
        [Display(Name = "Eğitmen")]
        public string InstructorId { get; set; } = string.Empty;

        public string InstructorName { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public int Progress { get; set; }

        [Display(Name = "Görsel URL")]
        public string ImageUrl { get; set; } = "/images/courses/default.jpg";
    }
}
