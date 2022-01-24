using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AliexpressItemsParser.Http;
using AliexpressItemsParser.Out;
using AliexpressItemsParser.Selenium;

namespace AliexpressItemsParser.Runner
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string itemId = "1005002715141420";

            await ParseWithHttpClient(itemId);
            await ParseWithSelenium(itemId);
        }

        static async Task ParseWithHttpClient(string itemId)
        {
            Console.WriteLine("Running ParseWithHttpClient...");
            Stopwatch sw = Stopwatch.StartNew();

            AliHttpScraper httpScraper = new AliHttpScraper();
            AliParser aliexpressItemsParser = new AliParser(httpScraper);
            AliexpressItem data = await aliexpressItemsParser.Parse(itemId);

            Print(data);
            Console.WriteLine($"Time elapsed: {sw.Elapsed}");
        }

        static async Task ParseWithSelenium(string itemId)
        {
            Console.WriteLine("Running ParseWithSelenium...");
            Stopwatch sw = Stopwatch.StartNew();

            using AliSeleniumScraper seleniumScraper = new AliSeleniumScraper();
            AliParser aliexpressItemsParser = new AliParser(seleniumScraper);
            AliexpressItem data = await aliexpressItemsParser.Parse(itemId);

            Print(data);
            Console.WriteLine($"Time elapsed: {sw.Elapsed}");
        }

        static void Print(AliexpressItem item)
        {
            Console.WriteLine($"Product: '{item.Name}'");
            Console.WriteLine($"Price: '{item.Price}'");
        }
    }
}