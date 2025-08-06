using Microsoft.Playwright;

namespace PlaywrightTests.Utilities
{
    public abstract class StepBase : IDisposable
    {
        protected readonly IPlaywright playwright;
        protected readonly IBrowser browser;
        protected readonly IPage page;

        protected StepBase()
        {
            playwright = Playwright.CreateAsync().GetAwaiter().GetResult();
            browser = playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true }).GetAwaiter().GetResult();
            page = browser.NewPageAsync().GetAwaiter().GetResult();
        }

        public void Dispose()
        {
            page?.CloseAsync().GetAwaiter().GetResult();
            browser?.CloseAsync().GetAwaiter().GetResult();
            playwright?.Dispose();
        }
    }
}