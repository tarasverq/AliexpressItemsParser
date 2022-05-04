using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Reviews;

internal class Style
{
    [JsonPropertyName("margin")]
    public string Margin { get; set; }

    [JsonPropertyName("padding")]
    public string Padding { get; set; }

    [JsonPropertyName("borderRadius")]
    public string BorderRadius { get; set; }
}