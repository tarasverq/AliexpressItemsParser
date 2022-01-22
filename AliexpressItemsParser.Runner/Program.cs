using System;
using System.Threading.Tasks;
using AliexpressItemsParser.Out;

namespace AliexpressItemsParser.Runner
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using AliexpressItemsParser aliexpressItemsParser = new AliexpressItemsParser();
            AliexpressItem data = await aliexpressItemsParser.Parse("1005002715141420");
            
            Console.WriteLine($"Product: '{data.Name}'");
            Console.WriteLine($"Price: '{data.Price}'");
        }
    }
}