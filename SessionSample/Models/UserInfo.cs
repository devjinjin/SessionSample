using System.Text.Json.Serialization;

namespace SessionSample.Models
{
    public record UserInfo
    {
        [JsonPropertyName("userId")]
        public string? USER_ID { get; set; }
    }
}
