using System;
using System.ComponentModel.DataAnnotations;

namespace AutismEducationPlatform.Web.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(2000)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Summary { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime PublishDate { get; set; } = DateTime.UtcNow;

        [StringLength(450)]
        public string? AuthorId { get; set; }

        public virtual ApplicationUser? Author { get; set; }

        [StringLength(200)]
        public string? ImageUrl { get; set; }
    }
} 