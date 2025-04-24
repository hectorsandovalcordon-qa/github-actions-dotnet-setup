﻿using Microsoft.Playwright;

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
            await _page.GotoAsync(_baseUrl + parameter);
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
