using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AliexpressItemsParser.Exceptions;
using AliexpressItemsParser.Interfaces;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace AliexpressItemsParser.Http;

public class AliHttpScraper : IAliScraper
{
    private readonly HttpClientHandler _handler;
    private readonly HttpClient _httpClient;
    
    public AliHttpScraper()
    {
        // Unable to use IHttpClientFactory here because of bug in .NET runtime:
        // https://github.com/dotnet/runtime/issues/60628
        // So we need whole HttpClientHandler to access the CookieContainer for using workaround
        _handler = new HttpClientHandler()
        {
            CookieContainer = new CookieContainer(),
            UseCookies = true,
            AllowAutoRedirect = false,
        };
        _httpClient = new HttpClient(_handler);
    }
    
    public async Task<string> GetDataString(string url)
    {
        HttpResponseMessage response = await _httpClient.SendAsyncWithCookieFix(
            new HttpRequestMessage(HttpMethod.Get, url), _handler.CookieContainer);
        if (!response.IsSuccessStatusCode)
        {
            throw new AliexpressItemsParserException($"Error when trying to get {url} data");
        }

        string responseString = await response.Content.ReadAsStringAsync();
        IHtmlDocument document = new HtmlParser().ParseDocument(responseString);
        
        IElement dataElement = document.QuerySelector("#__AER_DATA__");
        if (dataElement is null)
            throw new AliexpressItemsParserException("Unable to get element '__AER_DATA__'");
        
        string data = dataElement.InnerHtml;
        return data;
    }
}