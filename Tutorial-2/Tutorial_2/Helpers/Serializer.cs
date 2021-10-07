using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Tutorial_2.Models;

namespace Tutorial_2.Helpers
{
    public static class Serializer
    {
        public static string SerializeToJson(University university)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            return JsonSerializer.Serialize(university, options);
        }
    }
}