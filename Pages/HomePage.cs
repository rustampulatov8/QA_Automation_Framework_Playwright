using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace QA_Automation_Framework_Playwright.Pages
{
    public class HomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToHomePageAsync()
        {
            for (int attempt = 1; attempt <= 2; attempt++)
            {
                try
                {
                    await _page.GotoAsync("https://www.demoblaze.com/", new()
                    {
                        WaitUntil = WaitUntilState.DOMContentLoaded,
                        Timeout = 15000
                    });

                    await _page.WaitForSelectorAsync(".hrefch", new()
                    {
                        State = WaitForSelectorState.Visible,
                        Timeout = 10000
                    });

                    // Small delay for stability
                    await _page.WaitForTimeoutAsync(500);
                    return; // success
                }
                catch (TimeoutException) when (attempt < 2)
                {
                    Console.WriteLine($"[Retry] Home page load attempt {attempt} failed, retrying...");
                }
            }
        }

        public async Task ClickProductAsync(string productName)
        {
            // Wait for the page to be interactive
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            // Wait explicitly until product cards are loaded dynamically
            await _page.WaitForFunctionAsync(
                @"() => Array.from(document.querySelectorAll('.hrefch')).length >= 3",
                null,
                new() { Timeout = 60000 } // allow more time for GitHub runners
            );

            // Wait until the desired product is visible
            var productLocator = _page.Locator($".hrefch:has-text('{productName}')").First;
            for (int attempt = 1; attempt <= 3; attempt++)
            {
                if (await productLocator.IsVisibleAsync())
                {
                    await productLocator.ScrollIntoViewIfNeededAsync();
                    await productLocator.ClickAsync();
                    await _page.WaitForSelectorAsync("text=Add to cart", new() { Timeout = 20000 });
                    return;
                }

                Console.WriteLine($"[Retry {attempt}] Product '{productName}' not visible, refreshing...");
                await _page.ReloadAsync();
                await _page.WaitForTimeoutAsync(2000);
            }

            throw new TimeoutException($"❌ Product '{productName}' not found after 3 retries.");
        }


        public async Task AddToCartAsync()
        {
            var addToCartButton = _page.Locator("text=Add to cart");

            // Handle alert dialogs
            _page.Dialog += async (_, dialog) =>
            {
                await dialog.AcceptAsync();
            };

            await addToCartButton.ClickAsync();
            await _page.WaitForTimeoutAsync(1000);
        }
    }
}
