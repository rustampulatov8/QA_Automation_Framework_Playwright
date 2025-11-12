using Microsoft.Playwright;
using System.Threading.Tasks;

namespace QA_Automation_Framework_Playwright.Pages
{
    public class CheckoutPage
    {
        private readonly IPage _page;
        public CheckoutPage(IPage page) => _page = page;

        public async Task FillOrderFormAsync(string name, string country, string city, string card, string month, string year)
        {
            await _page.FillAsync("#name", name);
            await _page.FillAsync("#country", country);
            await _page.FillAsync("#city", city);
            await _page.FillAsync("#card", card);
            await _page.FillAsync("#month", month);
            await _page.FillAsync("#year", year);
            await _page.ClickAsync("text=Purchase");
        }

        public async Task<bool> VerifyConfirmationAsync() =>
            await _page.IsVisibleAsync("text=Thank you for your purchase!");
    }
}
