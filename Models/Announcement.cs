using System;
using System.ComponentModel.DataAnnotations;

namespace AutismEducationPlatform.Web.Models
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Content { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.UtcNow;

        [StringLength(50)]
        public string Type { get; set; } = string.Empty;

        public bool IsRead { get; set; }

        public bool IsActive { get; set; } = true;

        [StringLength(450)]
        public string? UserId { get; set; }

        public virtual ApplicationUser? User { get; set; }
    }
}