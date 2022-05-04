using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Reviews;

internal class Reviews
{
    [JsonPropertyName("widgetId")]
    public string WidgetId { get; set; }

    [JsonPropertyName("props")]
    public Props Props { get; set; }

    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }
}