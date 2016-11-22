using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SapientiaFons.Models
{
    public class Question
    {
        [Required]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Descripción")]
        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonIgnore]
        public Subject Subject { get; set; }

        [Required]
        [JsonIgnore]
        public int SubjectId { get; set; }

        [JsonIgnore]
        public Hypothesis Hypothesis { get; set; }

        [JsonProperty("hkey")]
        public int? HypothesisId { get; set; }
    }
}