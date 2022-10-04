using System.Text.Json.Serialization;

namespace Kanye.API.Model;

public class CommentRequest
{
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
    
    [JsonPropertyName("id")]
    public int? Id { get; set; }
    
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    
   [JsonPropertyName("body")] 
    public string? Body { get; set; }
}