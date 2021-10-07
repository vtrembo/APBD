using System.Text.Json.Serialization;

namespace Tutorial_2.Models
{
    public class Studies
    {
        [JsonPropertyName("course")]
        public string Course { get; set; }
        [JsonPropertyName("mode")]
        public string Mode { get; set; }
    }
}
