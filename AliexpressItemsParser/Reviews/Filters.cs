using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Reviews;

internal class Filters
{
    [JsonPropertyName("withPhoto")]
    public long WithPhoto { get; set; }

    [JsonPropertyName("withInfo")]
    public long WithInfo { get; set; }

    [JsonPropertyName("withAdditionalFeedback")]
    public long WithAdditionalFeedback { get; set; }

    [JsonPropertyName("currentCount")]
    public long CurrentCount { get; set; }

    [JsonPropertyName("onlyFromMyCountry")]
    public bool OnlyFromMyCountry { get; set; }

    [JsonPropertyName("translate")]
    public bool Translate { get; set; }
}