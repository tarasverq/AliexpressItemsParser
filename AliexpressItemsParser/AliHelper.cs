using System;
using System.Text.RegularExpressions;

namespace AliexpressItemsParser;

public static class AliHelper
{
    private static readonly Regex AliUrlRegex =
        new Regex(@"^http(s)?:\/\/(www\.)?aliexpress\.(\w{2,4})\/item\/(?<Id>\d+)\.html$");
    
    /// <summary>
    /// Tries to retrieve ItemId from aliexpress url
    /// </summary>
    /// <param name="url"></param>
    /// <param name="itemId"></param>
    /// <returns></returns>
    public static bool TryGetItemId(string url, out string itemId)
    {
        Match match = AliUrlRegex.Match(url.Trim());
        if (match.Success)
        {
            itemId =  match.Groups["Id"].Value;
            return true;
        }

        itemId = null;
        return false;
    }
    
    /// <summary>
    /// Makes url from ItemId
    /// </summary>
    /// <param name="itemId">Item id: e.g. 32376778613</param>
    /// <param name="domainZone">Domain zone: com, ru, etc... Default is "com"
    /// </param>
    /// <returns>Ready-to use url. E.g https://aliexpress.com/item/32376778613.html</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string MakeUrl(string itemId, string domainZone = "com")
    {
        if (string.IsNullOrWhiteSpace(itemId))
            throw new ArgumentNullException(nameof(itemId));
        
        if (string.IsNullOrWhiteSpace(domainZone))
            throw new ArgumentNullException(nameof(domainZone));
        
        return $"https://aliexpress.{domainZone}/item/{itemId}.html";
    }
}