using BoDi;
using Microsoft.Playwright;
using SpecFlowPlaywright.Drivers;

namespace SpecFlowPlaywright.Support
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;
        private BrowserDriver _browserDriver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public async Task Initialize()
        {
            _browserDriver = new BrowserDriver();
            _browser = await _browserDriver.CreateDriverAsync();
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
            await _page.SetViewportSizeAsync(1920, 1080);
            _objectContainer.RegisterInstanceAs(_page);
        }

        [AfterScenario]
        public async Task CleanUp()
        {
            await _page.CloseAsync();
            await _context.CloseAsync();
            await _browser.CloseAsync();
        }
    }
}
