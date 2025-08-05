using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class InstallationPage
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
            await _pageTitle.IsVisibleAsync();
        }
        catch (Exception e)
        {
            Assert.Fail("Failed to find specified Title - " + e.ToString());
        }
    }
}