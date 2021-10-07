using System.Text.Json.Serialization;

namespace Tutorial_2.Models
{
    public class Student
    {
        [JsonPropertyName("fname")]
        public string FirstName { get; set; }
        [JsonPropertyName("lname")]
        public string LastName { get; set; }
        [JsonPropertyName("snumber")]
        public string StudentNumber { get; set; }
        [JsonPropertyName("birthdate")]
        public string Birthdate { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("mothersname")]
        public string MothersName { get; set; }
        [JsonPropertyName("fathersname")]
        public string FathersName { get; set; }
  //      [JsonPropertyName("studies")]
  //      public Studies studies { get; set; }
        [JsonPropertyName("course")]
        public string Course { get; set; }
        [JsonPropertyName("mode")]
        public string Mode { get; set; }
    }
}