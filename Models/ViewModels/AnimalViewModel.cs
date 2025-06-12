using System.ComponentModel.DataAnnotations;

namespace AutismEducationPlatform.Web.Models.ViewModels
{
    public class AnimalViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string SoundPath { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Progress { get; set; } = 0; // 0-100 arası ilerleme
        public DateTime? LastInteraction { get; set; }
    }
} 