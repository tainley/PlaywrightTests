using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using PlaywrightTests.Utilities;
using static System.Net.WebRequestMethods;

namespace PlaywrightTests.Pages;

public class InstallationPage : PageTest
{
    private readonly IPage _page;
    private readonly ILocator _pageHeader;

    public InstallationPage(IPage page)
    {
        _page = page;
        _pageHeader = page.GetByRole(AriaRole.Heading, new() { Name = "Installation" });
    }

    public async Task AssertTitle()
    {
        try
        {
            await Expect(_pageHeader).ToBeVisibleAsync();
            await Expect(_page).ToHaveTitleAsync(Constants.pageTitle);
            await Expect(_page).ToHaveURLAsync(Constants.pageURL);
        }
        catch (Exception e)
        {
            Assert.Fail("Failed to find specified Title - " + e.ToString());
        }
    }
}