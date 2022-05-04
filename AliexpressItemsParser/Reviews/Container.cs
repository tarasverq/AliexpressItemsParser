using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Reviews;

internal class Container
{
    [JsonPropertyName("color")]
    public string Color { get; set; }

    [JsonPropertyName("style")]
    public Style Style { get; set; }
}