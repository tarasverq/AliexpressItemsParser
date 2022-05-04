using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Props;

internal class HideElements
{
    [JsonPropertyName("hideCart")]
    public bool HideCart { get; set; }

    [JsonPropertyName("hideFreight")]
    public bool HideFreight { get; set; }

    [JsonPropertyName("hideShipFrom")]
    public bool HideShipFrom { get; set; }

    [JsonPropertyName("hideSellerMenu")]
    public bool HideSellerMenu { get; set; }
}