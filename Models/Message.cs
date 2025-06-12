using System;
using System.ComponentModel.DataAnnotations;

namespace AutismEducationPlatform.Web.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(2000)]
        public string Content { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(100)]
        public string SenderName { get; set; } = string.Empty;

        [Required]
        [StringLength(450)]
        public string UserId { get; set; } = string.Empty;

        public virtual ApplicationUser User { get; set; } = null!;

        public bool IsRead { get; set; }
    }
} 