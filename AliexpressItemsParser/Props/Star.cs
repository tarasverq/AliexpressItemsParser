using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Props;

internal class Star
{
    [JsonPropertyName("value")]
    public long Value { get; set; }

    [JsonPropertyName("count")]
    public long Count { get; set; }

    [JsonPropertyName("percent")]
    public long Percent { get; set; }
}