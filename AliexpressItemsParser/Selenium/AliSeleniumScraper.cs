using System;
using System.Threading.Tasks;
using AliexpressItemsParser.Exceptions;
using AliexpressItemsParser.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AliexpressItemsParser.Selenium;

public class AliSeleniumScraper : IDisposable, IAliScraper
{
    private readonly Lazy<IWebDriver> _webDriver;

    public AliSeleniumScraper()
    {
        _webDriver = new Lazy<IWebDriver>(() =>
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.EnableVerboseLogging = false;
            service.SuppressInitialDiagnosticInformation = true;
            service.HideCommandPromptWindow = true;
            
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("headless");
            
            options.AddArgument("--disable-crash-reporter");
            options.AddArgument("--disable-logging");
            options.AddArgument("--log-level=3");
            options.AddArgument("--output=/dev/null");
            
            return new ChromeDriver(service, options);
        });
    }
    
    public AliSeleniumScraper(IWebDriver driver)
    {
        _webDriver = new Lazy<IWebDriver>(driver);
    }


    public Task<string> GetDataString(string url)
    {
        try
        {
            IWebDriver driver = _webDriver.Value;
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
            return Task.FromResult(json);
        }
        catch (Exception e) when (e is not AliexpressItemsParserException)
        {
            throw new AliexpressItemsParserException($"Error when trying to get {url} data", e);
        }
    }

    public void Dispose()
    {
        if (_webDriver.IsValueCreated)
        {
            _webDriver.Value?.Quit();
            _webDriver.Value?.Dispose();
        }
    }
}