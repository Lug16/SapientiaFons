using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SapientiaFons.Models
{
    public class Hypothesis
    {
        [Required]
        [JsonProperty("key")]
        public int Id { get; set; }

        [JsonIgnore]
        public Subject Subject { get; set; }

        [Required]
        [JsonIgnore]
        public int SubjectId { get; set; }

        [Required]
        [StringLength(500)]
        [DisplayFormat(NullDisplayText = "-")]
        [Display(Name = "Descripción")]
        [JsonProperty("desc")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Es Valido")]
        [JsonProperty("valid")]
        public bool IsValid { get; set; }
    }
}