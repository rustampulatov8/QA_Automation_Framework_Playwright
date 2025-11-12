using NUnit.Framework;
using QA_Automation_Framework_Playwright.Pages;
using QA_Automation_Framework_Playwright.Utilities;
using Microsoft.Playwright;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.IO;
using System.Threading.Tasks;

namespace QA_Automation_Framework_Playwright.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        private IPage _page;
        private IBrowser _browser;
        private ExtentReports _extent;
        private ExtentTest _test;

        [OneTimeSetUp]
        public void SetupReporting()
        {
            var reportsDir = Path.Combine(Directory.GetCurrentDirectory(), "Reports");
            Directory.CreateDirectory(reportsDir);

            var reportPath = Path.Combine(reportsDir, "Report.html");
            var spark = new ExtentSparkReporter(reportPath);

            _extent = new ExtentReports();
            _extent.AttachReporter(spark);
        }

        [SetUp]
        public async Task Setup()
        {
            // Initialize Playwright browser and page
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true // set to false if you want to see the browser window
            });
            var context = await _browser.NewContextAsync();
            _page = await context.NewPageAsync();

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public async Task ECommerce_Checkout_Flow()
        {
            try
            {
                var home = new HomePage(_page);
                var product = new ProductPage(_page);
                var cart = new CartPage(_page);
                var checkout = new CheckoutPage(_page);

                await home.NavigateToHomePageAsync();
                await home.ClickProductAsync("Samsung galaxy s6");
                await product.AddToCartAsync();
                await cart.GoToCartAsync();
                await cart.ProceedToCheckoutAsync();
                await checkout.FillOrderFormAsync("Rustam", "USA", "Tampa", "123456789012", "12", "2025");

                Assert.IsTrue(await checkout.VerifyConfirmationAsync(), "Purchase confirmation not visible");
                _test.Pass("Checkout flow completed successfully ✅");
            }
            catch (System.Exception ex)
            {
                // Log the failure and screenshot
                string screenshotPath = await ScreenshotHelper.TakeScreenshot(_page);
                _test.Fail($"Test failed ❌: {ex.Message}")
                     .AddScreenCaptureFromPath(screenshotPath);
                throw;
            }
        }

        [TearDown]
        public async Task TearDown()
        {
            // Close Playwright browser instance
            if (_browser != null)
                await _browser.CloseAsync();
        }

        [OneTimeTearDown]
        public void FlushReport()
        {
            _extent.Flush();

            // Optionally auto-open report after run (Windows only)
            string reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "Report.html");
            if (File.Exists(reportPath))
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = reportPath,
                    UseShellExecute = true
                });
        }
    }
}
