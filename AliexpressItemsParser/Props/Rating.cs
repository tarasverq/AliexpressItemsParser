using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Props;

internal class Rating
{
    [JsonPropertyName("middle")]
    public double Middle { get; set; }

    [JsonPropertyName("stars")]
    public List<Star> Stars { get; set; }
}