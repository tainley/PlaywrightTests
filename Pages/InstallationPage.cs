using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace PlaywrightTests.Pages;

public class InstallationPage : PageTest
{
    private readonly IPage _page;
    private readonly ILocator _pageTitle;

    public InstallationPage(IPage page)
    {
        _page = page;
        _pageTitle = page.GetByRole(AriaRole.Heading, new() { Name = "Installation" });
    }

    public async Task AssertTitle()
    {
        try
        {
            await Expect(_pageTitle).ToBeVisibleAsync();
            await Expect(_page).ToHaveTitleAsync("Installation | Playwright");
            await Expect(_page).ToHaveURLAsync("https://playwright.dev/docs/intro");
        }
        catch (Exception e)
        {
            Assert.Fail("Failed to find specified Title - " + e.ToString());
        }
    }
}