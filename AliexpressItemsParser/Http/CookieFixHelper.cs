using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AliexpressItemsParser.Http;

internal static class CookieFixHelper
{
    private const int MaxAutomaticRedirections = 10;
    private static Regex _replaceRegex = new Regex(@"(?<=Domain=)\.");

    /// <summary>
    /// Workaround for bug https://github.com/dotnet/runtime/issues/60628
    /// </summary>
    /// <param name="client"></param>
    /// <param name="requestMessage"></param>
    /// <param name="cookies"></param>
    /// <returns></returns>
    public static async Task<HttpResponseMessage> SendAsyncWithCookieFix(
        this HttpClient client,
        HttpRequestMessage requestMessage,
        CookieContainer cookies
    )
    {
        HttpResponseMessage response = await client.SendAsync(requestMessage);
        AssignCookies(response, cookies);

        string redirectLocation = response.Headers.Location?.ToString()!;
        
        int redirections = 0;
        while (!string.IsNullOrWhiteSpace(redirectLocation) && redirections <= MaxAutomaticRedirections)
        {
            response = await client.GetAsync(redirectLocation);
            AssignCookies(response, cookies);
            redirectLocation = response.Headers.Location?.ToString()!;
            redirections++;
        }

        return response;
    }

    private static void AssignCookies(HttpResponseMessage response, CookieContainer cookies)
    {
        Uri requestUri = response.RequestMessage?.RequestUri;
        if (response.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> values))
        {
            foreach (string value in values)
            {
                try
                {
                    string replaced = _replaceRegex.Replace(value, string.Empty);
                    cookies.SetCookies(requestUri!, replaced);
                }
                catch (CookieException)
                {
                }
            }
        }
    }
}