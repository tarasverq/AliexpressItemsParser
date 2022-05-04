using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Reviews;

internal class Props
{
    [JsonPropertyName("container")]
    public Container Container { get; set; }

    [JsonPropertyName("filters")]
    public Filters Filters { get; set; }

    [JsonPropertyName("count")]
    public long Count { get; set; }

    [JsonPropertyName("reviews")]
    public List<ReviewElement> Reviews { get; set; }

    [JsonPropertyName("rating")]
    public Rating Rating { get; set; }

    [JsonPropertyName("page")]
    public long Page { get; set; }

    [JsonPropertyName("totalPages")]
    public long TotalPages { get; set; }
}