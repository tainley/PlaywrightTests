using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace PlaywrightTests;

[TestClass]
public class ExampleTest : PageTest
{
    private const string BaseUrl = "https://playwright.dev";

    [TestMethod]
    public async Task PageTitle_ShouldContainPlaywright()
    {
        // Arrange & Act
        var response = await Page.GotoAsync(BaseUrl);
        Assert.IsTrue(response?.Ok ?? false, "Navigation to the base URL failed.");

        // Assert
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
    }

    [TestMethod]
    public async Task GetStartedLink_ShouldNavigateToInstallation()
    {
        // Arrange
        var response = await Page.GotoAsync(BaseUrl);
        Assert.IsTrue(response?.Ok ?? false, "Navigation to the base URL failed.");

        // Act
        await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

        // Assert
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
    }
}