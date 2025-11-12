using NUnit.Framework;
using Microsoft.Playwright;
using QA_Automation_Framework_Playwright.Pages;
using QA_Automation_Framework_Playwright.Utilities;
using System.Threading.Tasks;

namespace QA_Automation_Framework_Playwright.Tests
{
    [TestFixture]
    public class CartTests
    {
        private IPage _page;

        [SetUp]
        public async Task Setup()
        {
            _page = await BrowserFactory.CreatePageAsync();
        }

        [Test, TestCaseSource(typeof(TestDataHelper), nameof(TestDataHelper.LoadProducts))]
        public async Task AddProductToCart_DataDriven(string productName)
        {
            var home = new HomePage(_page);
            var product = new ProductPage(_page);
            var cart = new CartPage(_page);

            await home.NavigateToHomePageAsync();
            await home.ClickProductAsync(productName);
            await product.AddToCartAsync();
            await cart.GoToCartAsync();

            Assert.True(await _page.IsVisibleAsync($"text={productName}"),
                        $"{productName} not found in cart");
        }

        [Test]
public async Task AddMultipleProductsToCart()
{
    var home = new HomePage(_page);
    var product = new ProductPage(_page);
    var cart = new CartPage(_page);

    await home.NavigateToHomePageAsync();

    // Add first product
    await home.ClickProductAsync("Samsung galaxy s6");
    await product.AddToCartAsync();

    // Return to homepage and add second product
    await _page.GotoAsync("https://www.demoblaze.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
    await _page.WaitForSelectorAsync(".hrefch", new() { Timeout = 30000 });
    await home.ClickProductAsync("Nokia lumia 1520");
    await product.AddToCartAsync();

    // Go to cart page
    await cart.GoToCartAsync();

    // Wait for cart table to fully render
    await _page.WaitForSelectorAsync("#tbodyid tr", new() { Timeout = 10000 });

    // Check the number of products in the cart
    var cartRows = await _page.Locator("#tbodyid tr").CountAsync();
    System.Console.WriteLine($"🛒 Cart contains {cartRows} items.");

    // Validate both product names are visible
    bool hasSamsung = await _page.IsVisibleAsync("text=Samsung galaxy s6");
    bool hasNokia = await _page.IsVisibleAsync("text=Nokia lumia 1520");

    // Assert with clear message
    Assert.That(cartRows >= 2 && hasSamsung && hasNokia,
        $"Expected ≥2 products (Samsung, Nokia), but found {cartRows}. Samsung={hasSamsung}, Nokia={hasNokia}");
}


        [Test]
        public async Task RemoveItemFromCart()
        {
            var home = new HomePage(_page);
            var product = new ProductPage(_page);
            var cart = new CartPage(_page);

            await home.NavigateToHomePageAsync();
            await home.ClickProductAsync("Samsung galaxy s6");
            await product.AddToCartAsync();
            await cart.GoToCartAsync();

            // Assuming demoblaze cart has delete link
            await _page.ClickAsync("text=Delete");
            await _page.WaitForTimeoutAsync(2000);

            bool stillExists = await _page.IsVisibleAsync("text=Samsung galaxy s6");
            Assert.False(stillExists, "Product was not removed from cart.");
        }

        [OneTimeTearDown]
        public async Task TearDownAll()
        {
            await BrowserFactory.CloseAsync();
        }
    }
}
