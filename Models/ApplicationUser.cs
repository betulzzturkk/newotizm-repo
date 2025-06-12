using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutismEducationPlatform.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string? ParentName { get; set; }

        [StringLength(100)]
        public string? Specialization { get; set; }

        [StringLength(450)]
        public string? InstructorId { get; set; }

        public virtual ApplicationUser? Instructor { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        public DateTime? LastLoginDate { get; set; }

        [StringLength(100)]
        public string? FirstName { get; set; }

        [StringLength(100)]
        public string? LastName { get; set; }

        [StringLength(100)]
        public string? Surname { get; set; }

        [StringLength(50)]
        public string? Role { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLoginAt { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        // Child Information
        [StringLength(100)]
        [PersonalData]
        public string? ChildName { get; set; }

        [Range(1, 18)]
        [PersonalData]
        public int? ChildAge { get; set; }

        [StringLength(200)]
        [PersonalData]
        public string? ChildDiagnosis { get; set; }

        // Contact Information
        [StringLength(500)]
        [PersonalData]
        public string? Address { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}".Trim();

        public virtual ICollection<IdentityUserToken<string>> UserTokens { get; set; }

        [StringLength(200)]
        public string? ProfilePicture { get; set; }

        // Veli için özel alanlar
        public int? Experience { get; set; }

        [StringLength(100)]
        public string? EmergencyContact { get; set; }

        [StringLength(50)]
        public string? PreferredLanguage { get; set; }

        [StringLength(50)]
        public string? TimeZone { get; set; }

        public bool NotificationsEnabled { get; set; } = true;

        public ApplicationUser()
        {
            UserTokens = new HashSet<IdentityUserToken<string>>();
        }
    }
} 