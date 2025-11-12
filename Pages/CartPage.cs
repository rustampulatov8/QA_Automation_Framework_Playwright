using Microsoft.Playwright;
using System.Threading.Tasks;

namespace QA_Automation_Framework_Playwright.Pages
{
    public class CartPage
    {
        private readonly IPage _page;

        public CartPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToCartAsync()
        {
            // Click Cart and wait for navigation to complete
            await _page.ClickAsync("#cartur");
            await _page.WaitForURLAsync("**/cart.html", new() { Timeout = 20000 });

            // Wait until the cart table is fully rendered
            await _page.WaitForSelectorAsync("#tbodyid tr", new() { Timeout = 20000 });
        }

        public async Task ProceedToCheckoutAsync()
        {
            // Make sure the "Place Order" button exists and is visible
            var placeOrderButton = _page.Locator("button.btn.btn-success:has-text('Place Order')");
            await placeOrderButton.First.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });
            await placeOrderButton.First.ClickAsync();

            // Wait for order modal popup
            await _page.WaitForSelectorAsync("#orderModal", new() { State = WaitForSelectorState.Visible, Timeout = 15000 });
        }

        public async Task FillCheckoutFormAsync(string name, string country, string city, string card, string month, string year)
        {
            await _page.FillAsync("#name", name);
            await _page.FillAsync("#country", country);
            await _page.FillAsync("#city", city);
            await _page.FillAsync("#card", card);
            await _page.FillAsync("#month", month);
            await _page.FillAsync("#year", year);
        }

        public async Task ConfirmPurchaseAsync()
        {
            await _page.ClickAsync("button.btn.btn-primary:has-text('Purchase')");
            await _page.WaitForSelectorAsync(".sweet-alert", new() { Timeout = 15000 });
        }
    }
}
