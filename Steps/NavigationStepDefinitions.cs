using Microsoft.Playwright;
using PlaywrightTests.Pages;
using Reqnroll;

namespace PlaywrightTests.Steps
{
    [Binding]
    public class NavigationStepDefinitions
    {
        private readonly HomePage homePage;
        private readonly InstallationPage installationPage;

        public NavigationStepDefinitions()
        {
            IPlaywright playwright = Microsoft.Playwright.Playwright.CreateAsync().GetAwaiter().GetResult();
            IBrowser browser = playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true }).GetAwaiter().GetResult();
            IPage page = browser.NewPageAsync().GetAwaiter().GetResult();

            this.homePage = new HomePage(page);
            this.installationPage = new InstallationPage(page);
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
    }
}
