using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResumeManager.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string? Gender { get; set; }

        [Range(22, 55)]
        public int? Age { get; set; }

        [StringLength(50)]
        public string? Qualification { get; set; }

        [Required]
        [Display(Name ="Total Experience in year")]
        public int TotalExperience { get; set; }

        public virtual List<Experience> Experiences { get; set; } = new List<Experience>();

        public string PhotoUrl { get; set; }
        [Required(ErrorMessage ="please choose the photo")]
        [Display(Name ="Profile Photo")]
        [NotMapped]
        public IFormFile ProfilePhoto { get; set; }


    }
}
