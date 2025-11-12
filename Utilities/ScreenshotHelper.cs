using Microsoft.Playwright;
using System.IO;
using System.Threading.Tasks;

namespace QA_Automation_Framework_Playwright.Utilities
{
    public static class ScreenshotHelper
    {
        public static async Task<string> TakeScreenshot(IPage page)
        {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "Screenshots");
            Directory.CreateDirectory(dir);
            var path = Path.Combine(dir, $"screenshot_{System.DateTime.Now:HHmmss}.png");
            await page.ScreenshotAsync(new PageScreenshotOptions { Path = path });
            return path;
        }
    }
}
