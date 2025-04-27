using Microsoft.Playwright;

namespace SpecFlowPlaywright.Drivers
{
    public class BrowserDriver
    {
        public async Task<IBrowser> CreateDriverAsync()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });
            return browser;
        }
    }
}
