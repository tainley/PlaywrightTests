using PlaywrightTests.Pages;
using PlaywrightTests.Utilities;
using Reqnroll;

namespace PlaywrightTests.Steps
{
    [Binding]
    public class NavigationStepDefinitions : StepBase
    {
        private readonly HomePage homePage;
        private readonly InstallationPage installationPage;

        public NavigationStepDefinitions()
        {
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
    }
}
