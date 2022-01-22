using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AliexpressItemsParser.Exceptions;
using AliexpressItemsParser.Out;
using Mapster;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AliexpressItemsParser
{
    public class AliParser : IDisposable
    {
        private const string DomainZone = "com";
        private static Regex itemIdRegex = new Regex(@"^\d+$");
        private readonly Lazy<IWebDriver> _webDriver;

        static AliParser()
        {
            TypeAdapterConfig.GlobalSettings.Scan(typeof(AliParser).Assembly);
        }

        public AliParser()
        {
            _webDriver = new Lazy<IWebDriver>(() =>
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("headless");
                return new ChromeDriver(options);
            });
        }

        public AliParser(IWebDriver driver)
        {
            _webDriver = new Lazy<IWebDriver>(driver);
        }

        public Task<AliexpressItem> Parse(string itemId)
        {
            if (!itemIdRegex.IsMatch(itemId))
                throw new AliexpressItemsParserException("ItemId is not in right format");
            try
            {
                IWebDriver driver = _webDriver.Value;
                string url = $"https://aliexpress.{DomainZone}/item/{itemId}.html";
                driver.Navigate().GoToUrl(url);

                IWebElement data;
                try
                {
                    data = driver.FindElement(By.Id("__AER_DATA__"));
                }
                catch (Exception e)
                {
                    throw new AliexpressItemsParserException("Unable to get element '__AER_DATA__'", e);
                }

                string json = data.GetAttribute("innerHTML");
                AliexpressItem aliItem = ParseJson(json);
                aliItem.ItemUrl = url;
                return Task.FromResult(aliItem);
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

        public void Dispose()
        {
            if (_webDriver.IsValueCreated)
                _webDriver?.Value?.Dispose();
        }
    }
}