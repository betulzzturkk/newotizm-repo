using System;

namespace AutismEducationPlatform.Web.Models.ViewModels
{
    public class AnnouncementViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty;
        public bool IsRead { get; set; }
    }
}
