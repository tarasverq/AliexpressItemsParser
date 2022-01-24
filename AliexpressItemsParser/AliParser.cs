using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AliexpressItemsParser.Exceptions;
using AliexpressItemsParser.Interfaces;
using AliexpressItemsParser.Out;
using Mapster;

namespace AliexpressItemsParser
{
    public class AliParser : IAliParser
    {
        private readonly IAliScraper _scraper;
        private const string DomainZone = "com";
        private static Regex itemIdRegex = new Regex(@"^\d+$");

        static AliParser()
        {
            TypeAdapterConfig.GlobalSettings.Scan(typeof(AliParser).Assembly);
        }

        public AliParser(IAliScraper scraper)
        {
            _scraper = scraper;
        }


        public async Task<AliexpressItem> Parse(string itemId)
        {
            if (!itemIdRegex.IsMatch(itemId))
                throw new AliexpressItemsParserException("ItemId is not in right format");
            try
            {
                string url = $"https://aliexpress.{DomainZone}/item/{itemId}.html";
                string json = await _scraper.GetDataString(url);
                AliexpressItem aliItem = ParseJson(json);
                aliItem.ItemUrl = url;
                return aliItem;
            }
            catch (Exception e) when (e is not AliexpressItemsParserException)
            {
                throw new AliexpressItemsParserException($"Error when trying to get item {itemId} data", e);
            }
        }

        protected virtual AliexpressItem ParseJson(string json)
        {
            JsonDocument models = JsonDocument.Parse(json);

            JsonElement? widget = models.SelectElement("widgets[0]");
            if (!widget.HasValue)
                throw new AliexpressItemsParserException("Unable to find 'widgets[0]' in json string", json);

            JsonElement? props = widget.Value.SelectElement("props");
            if (!props.HasValue)
                throw new AliexpressItemsParserException("Unable to find 'props' in json string", json);

            Props.Props properties = JsonSerializer.Deserialize<Props.Props>(props.Value);
            if (properties == null)
                throw new AliexpressItemsParserException("Unable to deserealize properties", json);

            AliexpressItem aliItem = properties.Adapt<AliexpressItem>();

            JsonElement? reviewsJson = models.SelectElements(@"$..[?(@.widgetId =~ /bx\/Reviews\/.*?/i)]")
                .FirstOrDefault();

            if (reviewsJson == null || !reviewsJson.HasValue)
                throw new AliexpressItemsParserException("Unable to find 'reviews' object in json string", json);

            Reviews.Reviews reviews = JsonSerializer.Deserialize<Reviews.Reviews>(reviewsJson.Value);
            if (reviews == null)
                throw new AliexpressItemsParserException("Unable to deserealize reviews", json);

            ICollection<Review> outReviews = reviews.Props.Reviews.Adapt<ICollection<Review>>();

            aliItem.Reviews = outReviews;
            return aliItem;
        }

    }
}