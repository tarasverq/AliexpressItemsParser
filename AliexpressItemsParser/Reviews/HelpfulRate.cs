using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Reviews;

internal class HelpfulRate
{
    [JsonPropertyName("helpfulCounter")]
    public long HelpfulCounter { get; set; }

    [JsonPropertyName("uselessCounter")]
    public long UselessCounter { get; set; }
}