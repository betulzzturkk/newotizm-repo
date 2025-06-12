using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutismEducationPlatform.Web.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Type { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Difficulty { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public bool IsActive { get; set; } = true;

        public int Score { get; set; }

        [Range(1, 180)]
        public int DurationMinutes { get; set; }

        public DateTime? CompletionDate { get; set; }

        [StringLength(450)]
        public string? UserId { get; set; }

        public virtual ApplicationUser? User { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
    }
} 