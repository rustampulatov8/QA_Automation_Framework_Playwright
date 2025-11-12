using Microsoft.Playwright;
using System.Threading.Tasks;

namespace QA_Automation_Framework_Playwright.Utilities
{
    public static class BrowserFactory
    {
        private static IPlaywright? _playwright;
        private static IBrowser? _browser;

        public static async Task<IPage> CreatePageAsync()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = true, // ✅ CI requires headless mode
                Args = new[] { "--no-sandbox", "--disable-dev-shm-usage" }
            });

            var context = await browser.NewContextAsync();
            return await context.NewPageAsync();
        }

        public static async Task CloseAsync()
        {
            if (_browser != null)
            {
                await _browser.CloseAsync();
                _browser = null;
            }

            if (_playwright != null)
            {
                _playwright.Dispose();
                _playwright = null;
            }
        }
    }
}
