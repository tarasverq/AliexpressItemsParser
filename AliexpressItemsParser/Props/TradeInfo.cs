using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Props;

internal class TradeInfo
{
    [JsonPropertyName("tradeCount")]
    public string TradeCount { get; set; }

    [JsonPropertyName("formatTradeCount")]
    public string FormatTradeCount { get; set; }

    [JsonPropertyName("tradeCountUnit")]
    public string TradeCountUnit { get; set; }
}