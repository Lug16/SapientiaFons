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
        public string Description { get; set; }

        [Required]
        public bool IsValid { get; set; }
    }
}