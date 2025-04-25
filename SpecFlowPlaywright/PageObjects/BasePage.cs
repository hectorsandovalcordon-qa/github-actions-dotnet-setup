using Microsoft.Playwright;

namespace SpecFlowPlaywright.PageObjects
{
    public class BasePage
    {
        protected readonly IPage _page;

        private const string _baseUrl = "https://demoqa.com/";

        public BasePage(IPage page)
        {
            _page = page;
        }

        public async Task OpenAsync(string parameter)
        {
            await page.GotoAsync(_baseUrl + parameter, new()
            {
                WaitUntil = WaitUntilState.DOMContentLoaded,
                Timeout = 10000
            });
        }

        public async Task<ILocator> WaitElementAsync(string selector)
        {
            await _page.WaitForSelectorAsync(selector, new PageWaitForSelectorOptions
            {
                Timeout = 10000
            });
            return _page.Locator(selector);
        }

    }
}
