using SapientiaFons.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SapientiaFons.Models
{
    public class Activity
    {
        public int Id { get; set; }

        public Subject Subject { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public ActivityTypes Type { get; set; }
    }
}