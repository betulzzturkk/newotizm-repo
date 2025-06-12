using System.ComponentModel.DataAnnotations;

namespace AutismEducationPlatform.Web.Models
{
    public class FAQ
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Question { get; set; } = string.Empty;

        [Required]
        [StringLength(2000)]
        public string Answer { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public int OrderIndex { get; set; }
    }
} 