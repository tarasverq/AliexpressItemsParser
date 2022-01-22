using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Out;

public class AliexpressItem
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("gallery")]
    public ICollection<Gallery> Gallery { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("likes")]
    public long Likes { get; set; }

    [JsonPropertyName("price")]
    public string Price { get; set; }

    [JsonPropertyName("rating")]
    public double Rating { get; set; }

    [JsonPropertyName("reviews_count")]
    public string ReviewsCount { get; set; }

    [JsonPropertyName("storeUrl")]
    public string StoreUrl { get; set; }

    [JsonPropertyName("sellerId")]
    public string SellerId { get; set; }

    [JsonPropertyName("reviews")]
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}