using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Props;

internal class Amount
{
    [JsonPropertyName("value")]
    public double Value { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("formatted")]
    public string Formatted { get; set; }
}