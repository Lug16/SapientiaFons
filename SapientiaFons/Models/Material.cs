using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SapientiaFons.Models
{
    public class Material
    {
        [JsonIgnore]
        public Subject Subject { get; set; }

        [Required]
        [JsonIgnore]
        public int SubjectId { get; set; }

        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        [JsonProperty("type")]
        public Enums.MaterialTypes Type { get; set; }

        [Required]
        [StringLength(2083)]
        [Display(Name = "Ubicación")]
        [JsonProperty("location")]
        public string Location { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Descripción")]
        [JsonProperty("description")]
        public string Description { get; set; }
    }

}