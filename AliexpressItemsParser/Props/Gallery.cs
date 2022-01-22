using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Props;

internal class Gallery
{
    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("previewUrl")]
    public string PreviewUrl { get; set; }

    [JsonPropertyName("videoUrl")]
    public string VideoUrl { get; set; }
}