using System;

namespace AutismEducationPlatform.Web.Models.ViewModels
{
    public class ActivityProgress
    {
        // InstructorController'daki mevcut kullanımlar:
        public int ActivityId { get; set; }
        public DateTime CompletionDate { get; set; }
        public int Score { get; set; }
        public bool IsCompleted { get; set; }

        // Daha önceki mevcut alanlar da korunuyor:
        public string ActivityName { get; set; } = string.Empty;
        public int CompletionCount { get; set; }
        public double SuccessRate { get; set; }
        public DateTime LastAttemptDate { get; set; }
    }
}