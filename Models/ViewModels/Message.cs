using System;

namespace AutismEducationPlatform.Web.Models.ViewModels
{
    public class Message
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public bool IsRead { get; set; }
    }
} 