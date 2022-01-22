using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Props;

internal class Props
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("gallery")]
    public List<Gallery> Gallery { get; set; }

    [JsonPropertyName("aePlus")]
    public object AePlus { get; set; }

    [JsonPropertyName("titleTags")]
    public List<object> TitleTags { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("freeReturn")]
    public object FreeReturn { get; set; }

    [JsonPropertyName("likes")]
    public long Likes { get; set; }

    [JsonPropertyName("liked")]
    public bool Liked { get; set; }

    [JsonPropertyName("price")]
    public Price Price { get; set; }

    [JsonPropertyName("rating")]
    public Rating Rating { get; set; }

    [JsonPropertyName("tradeInfo")]
    public TradeInfo TradeInfo { get; set; }

    [JsonPropertyName("reviews")]
    public string Reviews { get; set; }

    [JsonPropertyName("isLogin")]
    public bool IsLogin { get; set; }

    [JsonPropertyName("itemStatus")]
    public long ItemStatus { get; set; }

    [JsonPropertyName("vehicleInfo")]
    public object VehicleInfo { get; set; }

    [JsonPropertyName("fitPredict")]
    public object FitPredict { get; set; }

    [JsonPropertyName("freebiesCount")]
    public string FreebiesCount { get; set; }

    [JsonPropertyName("itemMinPrice")]
    public string ItemMinPrice { get; set; }

    [JsonPropertyName("sellerAdminSeq")]
    public string SellerAdminSeq { get; set; }

    [JsonPropertyName("activeSkuId")]
    public string ActiveSkuId { get; set; }

    [JsonPropertyName("hideElements")]
    public HideElements HideElements { get; set; }

    [JsonPropertyName("uniformBanner")]
    public object UniformBanner { get; set; }

    [JsonPropertyName("storeUrl")]
    public string StoreUrl { get; set; }

    [JsonPropertyName("sellerId")]
    public string SellerId { get; set; }
}