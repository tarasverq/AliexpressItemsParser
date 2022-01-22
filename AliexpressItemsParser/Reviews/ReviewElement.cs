using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Reviews;

internal class ReviewElement
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

    [JsonPropertyName("additionalInfo")]
    public List<AdditionalInfo> AdditionalInfo { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("helpfulRate")]
    public HelpfulRate HelpfulRate { get; set; }

    [JsonPropertyName("gallery")]
    public ICollection<string> Gallery { get; set; }

    [JsonPropertyName("additionalReview")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

    public AdditionalReview AdditionalReview { get; set; }
}