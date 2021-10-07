using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tutorial_2.Models
{
    public class University
    {
        [JsonPropertyName("createdAt")]
        public string createdAt { get; set; }
        [JsonPropertyName("author")]
        public string author { get; set; }
        [JsonPropertyName("students")]
        public HashSet<Student> students { get; set; }
        [JsonPropertyName("activeStudies")]
        public HashSet<ActiveStudies> activeStudies { get; set; }
    }
}
