using Microsoft.Playwright;
using System.Threading.Tasks;

namespace QA_Automation_Framework_Playwright.Pages
{
    public class ProductPage
    {
        private readonly IPage _page;
        public ProductPage(IPage page) => _page = page;

        public async Task AddToCartAsync()
        {
            var addToCartButton = _page.Locator("text=Add to cart");

            // One-time handler to avoid "dialog already handled" crashes
            void DialogHandler(object? sender, IDialog dialog)
            {
                _ = dialog.AcceptAsync(); // fire-and-forget acceptance
                _page.Dialog -= DialogHandler; // detach immediately
            }

            _page.Dialog += DialogHandler;

            await addToCartButton.ClickAsync();

            // Allow dialog to appear and disappear
            await _page.WaitForTimeoutAsync(1500);
        }
    }
}
