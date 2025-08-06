using Microsoft.Playwright;
using PlaywrightTests.Pages;
using Reqnroll;

namespace PlaywrightTests.Steps
{
    [Binding]
    public class NavigationStepDefinitions : IDisposable
    {
        private readonly IPlaywright playwright;
        private readonly IBrowser browser;
        private readonly IPage page;
        private readonly HomePage homePage;
        private readonly InstallationPage installationPage;

        public NavigationStepDefinitions()
        {
            playwright = Playwright.CreateAsync().GetAwaiter().GetResult();
            browser = playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true }).GetAwaiter().GetResult();
            page = browser.NewPageAsync().GetAwaiter().GetResult();
            homePage = new HomePage(page);
            installationPage = new InstallationPage(page);
        }

        [Given("I am on the homepage")]
        public async Task GivenIAmOnTheHomepage()
        {
            await homePage.GoToHomePage();
        }

        [When("I click on the Get Started link")]
        public async Task WhenIClickOnTheGetStartedLink()
        {
            await homePage.ClickGetStarted();
        }

        [Then("I should see the Installation page")]
        public async Task ThenIShouldSeeTheInstallationPage()
        {
            await installationPage.AssertTitle();
        }

        public void Dispose()
        {
            page?.CloseAsync().GetAwaiter().GetResult();
            browser?.CloseAsync().GetAwaiter().GetResult();
            playwright?.Dispose();
        }
    }
}
