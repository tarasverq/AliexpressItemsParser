using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Reviews;

internal class Rating
{
    [JsonPropertyName("detailed")]
    public List<Detailed> Detailed { get; set; }

    [JsonPropertyName("average")]
    public double Average { get; set; }
}