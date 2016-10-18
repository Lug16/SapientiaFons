using System.ComponentModel.DataAnnotations;

namespace SapientiaFons.Models
{
    public class Material
    {
        public Subject Subject { get; set; }

        [Required]
        public int SubjectId { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "Tipo")]
        public string Type { get; set; }

        [Required]
        [StringLength(2083)]
        [Display(Name = "Ubicación")]
        public string Location { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
    }

}