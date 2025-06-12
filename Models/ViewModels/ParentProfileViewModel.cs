using System;
using System.ComponentModel.DataAnnotations;

namespace AutismEducationPlatform.Web.Models.ViewModels
{
    public class ParentProfileViewModel
    {
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        public string Name => $"{FirstName} {LastName}";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string EmergencyContact { get; set; } = string.Empty;
        public string PreferredLanguage { get; set; } = string.Empty;
        public string TimeZone { get; set; } = string.Empty;
        public bool NotificationsEnabled { get; set; } = true;

        [Required]
        public string ChildName { get; set; } = string.Empty;

        [Range(1, 18)]
        public int ChildAge { get; set; }

        public string ChildDiagnosis { get; set; } = string.Empty;
        public string ChildSchool { get; set; } = string.Empty;
        public string ChildTherapist { get; set; } = string.Empty;
        public string ChildMedicalHistory { get; set; } = string.Empty;
        public string ChildAllergies { get; set; } = string.Empty;
        public string ChildMedications { get; set; } = string.Empty;
        public string ChildBehavioralNotes { get; set; } = string.Empty;
        public string ChildEducationalGoals { get; set; } = string.Empty;
    }
}