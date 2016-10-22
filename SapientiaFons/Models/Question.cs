using System.ComponentModel.DataAnnotations;

namespace SapientiaFons.Models
{
    public class Question
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        public Subject Subject { get; set; }

        [Required]
        public int SubjectId { get; set; }

        public Hypothesis Hypothesis { get; set; }

        public int? HypothesisId { get; set; }
    }
}