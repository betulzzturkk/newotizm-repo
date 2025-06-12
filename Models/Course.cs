using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AutismEducationPlatform.Web.Models
{
    public class Course
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
        public string Category { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime? CompletionDate { get; set; }

        [StringLength(450)]
        public string? InstructorId { get; set; }

        public virtual ApplicationUser? Instructor { get; set; }

        public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

        [Range(1, 5)]
        public int DifficultyLevel { get; set; } = 1;

        [StringLength(200)]
        public string ImageUrl { get; set; } = "/images/courses/default.jpg";

        [Range(1, 180)]
        public int DurationMinutes { get; set; }

        public string Title { get; set; } = string.Empty;
        public string IconClass { get; set; } = string.Empty;
        public string BackgroundColor { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
} 