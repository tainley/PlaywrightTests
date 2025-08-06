using Microsoft.Playwright.MSTest;
using PlaywrightTests.Pages;

namespace PlaywrightTests.Tests;

[TestClass]
public partial class TestB : PageTest
{
    private HomePage _homePage;
    private InstallationPage _installationPage;

    [TestInitialize]
    public void Setup()
    {
        _homePage = new HomePage(Page);
        _installationPage = new InstallationPage(Page);
    }

    [TestMethod]
    public async Task PageLinksB()
    {
        await _homePage.GoToHomePage();
        await _homePage.ClickGetStarted();
        await _installationPage.AssertTitle();
    }
}