using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace QA_Automation_Framework_Playwright.Utilities
{
    public static class TestDataHelper
    {
        public static IEnumerable<string> LoadProducts()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "TestData", "Products.json");
            string json = File.ReadAllText(path);
            var doc = JsonDocument.Parse(json);
            foreach (var product in doc.RootElement.GetProperty("Products").EnumerateArray())
            {
                yield return product.GetString();
            }
        }
    }
}
