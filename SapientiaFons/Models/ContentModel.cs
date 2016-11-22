
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SapientiaFons.Models
{
    public class ContentModel
    {
        [JsonProperty("description")]
        public string Description { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("content")]
        public ContentBody Body { get; set; }

        public ContentModel()
        {
            this.Body = new ContentBody();
        }
    }

    public class ContentBody
    {
        [JsonProperty("material")]
        public IEnumerable<Material> Materials { get; set; }

        [JsonProperty("hypotheses")]
        public IEnumerable<Hypothesis> Hypotheses { get; set; }

        [JsonProperty("questions")]
        public IEnumerable<Question> Questions { get; set; }
    }
}