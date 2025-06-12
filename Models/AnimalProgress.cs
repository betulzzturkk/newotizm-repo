using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutismEducationPlatform.Web.Models
{
    public class AnimalProgress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AnimalId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int ProgressValue { get; set; } = 0;

        public int InteractionCount { get; set; } = 0;

        public DateTime LastInteraction { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
} 