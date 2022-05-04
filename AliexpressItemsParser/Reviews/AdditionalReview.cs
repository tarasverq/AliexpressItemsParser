using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AliexpressItemsParser.Reviews;

internal class AdditionalReview
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("gallery")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Uri> Gallery { get; set; }
}