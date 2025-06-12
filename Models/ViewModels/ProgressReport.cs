using System;
using System.Collections.Generic;

namespace AutismEducationPlatform.Web.Models.ViewModels
{
    public class ProgressReport
    {
        public int TotalCourses { get; set; }
        public int CompletedCourses { get; set; }
        public int TotalActivities { get; set; }
        public int CompletedActivities { get; set; }
        public double CompletionPercentage { get; set; }
        public double AverageScore { get; set; }
        public DateTime LastActivity { get; set; }
        public List<ActivityProgress> ActivityProgress { get; set; } = new();
    }
} 