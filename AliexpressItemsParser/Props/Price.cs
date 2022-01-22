using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Props;

internal class Price
{
    [JsonPropertyName("activity")]
    public bool Activity { get; set; }

    [JsonPropertyName("discount")]
    public long Discount { get; set; }

    [JsonPropertyName("formattedActivityPrice")]
    public string FormattedActivityPrice { get; set; }

    [JsonPropertyName("formattedPrice")]
    public string FormattedPrice { get; set; }

    [JsonPropertyName("lot")]
    public bool Lot { get; set; }

    [JsonPropertyName("numberPerLot")]
    public long NumberPerLot { get; set; }

    [JsonPropertyName("multiUnitName")]
    public string MultiUnitName { get; set; }

    [JsonPropertyName("maxActivityAmount")]
    public Amount MaxActivityAmount { get; set; }

    [JsonPropertyName("minActivityAmount")]
    public Amount MinActivityAmount { get; set; }

    [JsonPropertyName("maxAmount")]
    public Amount MaxAmount { get; set; }

    [JsonPropertyName("minAmount")]
    public Amount MinAmount { get; set; }

    public override string ToString()
    {
        if (Activity)
            return FormattedActivityPrice;
        return FormattedPrice;
    }
}