using System.Text.Json.Serialization;


namespace Tutorial_2.Models
{
    public class ActiveStudies
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("numberOfStudents")]
        public int numberOfStudents { get; set; }

    }
}
