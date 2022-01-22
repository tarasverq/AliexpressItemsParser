using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Out;

public class Review
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("userUrl")]
    public string UserUrl { get; set; }

    [JsonPropertyName("rating")]
    public long Rating { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("gallery")]
    public ICollection<string> Gallery { get; set; }
}