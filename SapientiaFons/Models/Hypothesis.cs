using System.ComponentModel.DataAnnotations;

namespace SapientiaFons.Models
{
    public class Hypothesis
    {
        [Required]
        public int Id { get; set; }
        public Subject Subject { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        [StringLength(500)]
        [DisplayFormat(NullDisplayText = "-")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Es Valido")]
        public bool IsValid { get; set; }
    }
}