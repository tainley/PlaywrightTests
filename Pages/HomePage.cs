using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace PlaywrightTests.Pages;

public class HomePage: PageTest
{
    private readonly IPage _page;
    private readonly ILocator _getStarted;

    public HomePage(IPage page)
    {
        _page = page;
        _getStarted = page.GetByRole(AriaRole.Link, new() { Name = "Get started" });
    }

    public async Task GoToHomePage()
    {
        try
        {
            await _page.GotoAsync(Utilities.Constants.BaseUrl);
        }
        catch (Exception e)
        {
            Assert.Fail("Failed to open Home Page URL - " + e.ToString());
        }
    }

    public async Task ClickGetStarted()
    {
        try
        {
            await _getStarted.ClickAsync();
        }
        catch (Exception e)
        {
            Assert.Fail("Failed to click Get Started link  - " + e.ToString());
        }
    }
}