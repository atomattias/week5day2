using System.Text.Json.Serialization;

namespace Kanye.API.Model;

public class KanyeResponse
{
    [JsonPropertyName("quote")]
    public string? Quote { get; set; }
    public DateTime ResponseAt { get; set; }
    public string Id { get; set; }
}