using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Reviews;

internal class AdditionalInfo
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}