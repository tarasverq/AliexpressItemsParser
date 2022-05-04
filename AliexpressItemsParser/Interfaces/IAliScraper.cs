using System.Threading.Tasks;

namespace AliexpressItemsParser.Interfaces;

public interface IAliScraper
{
    Task<string> GetDataString(string url);
    Task<bool> IsItemExists(string itemId);
}