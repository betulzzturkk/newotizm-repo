using System;
using System.Collections.Generic;

namespace AutismEducationPlatform.Web.Models.ViewModels
{
    public class InstructorDashboardViewModel
    {
        public InstructorInfo InstructorInfo { get; set; } = new InstructorInfo();
        public List<CourseViewModel> AssignedCourses { get; set; } = new();
        public List<StudentInfo> Students { get; set; } = new();
        public List<ActivityProgress> Activities { get; set; } = new();
        public List<AnnouncementViewModel> Announcements { get; set; } = new(); // 🔧 ViewModel
        public List<MessageViewModel> Messages { get; set; } = new();
        public UserProfileViewModel UserProfile { get; set; } = new UserProfileViewModel();
    }

    public class InstructorInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;
        public string Certifications { get; set; } = string.Empty;
        public string Languages { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
        public int TotalStudents { get; set; }
        public int ActiveCourses { get; set; }
        public double AverageRating { get; set; }
        public string Expertise { get; set; } = string.Empty;
    }

    public class StudentInfo
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string ParentName { get; set; } = string.Empty;
        public string ParentContact { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public string ProgressStatus { get; set; } = string.Empty;
        public DateTime LastActivity { get; set; }
        public List<ActivityProgress> RecentActivities { get; set; } = new();
    }
}