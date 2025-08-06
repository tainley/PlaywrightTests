using Microsoft.Playwright.MSTest;
using PlaywrightTests.Pages;

namespace PlaywrightTests.Tests;

[TestClass]
public partial class TestA : PageTest
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
    public async Task PageLinksA()
    {
        try
        {
            await _homePage.GoToHomePage();
            await _homePage.ClickGetStarted();
            await _installationPage.AssertTitle();
        }
        catch (Exception e)
        {
            Assert.Fail("Page Links test A failed - " + e.ToString());
        }
    }
  }