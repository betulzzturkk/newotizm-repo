namespace AutismEducationPlatform.Web.Models.ViewModels
{
    public class UserProfileViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string LastLoginDate { get; set; } = string.Empty;
        public string RegistrationDate { get; set; } = string.Empty;
        public string PreferredLanguage { get; set; } = string.Empty;
        public string TimeZone { get; set; } = string.Empty;
        public bool NotificationsEnabled { get; set; } = true;
    }
} 