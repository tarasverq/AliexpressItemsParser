using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Reviews;

internal class Detailed
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("percent")]
    public long Percent { get; set; }
}