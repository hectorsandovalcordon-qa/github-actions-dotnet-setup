using BoDi;
using Microsoft.Playwright;
using SpecFlowPlaywright.PageObjects;

namespace SpecFlowPlaywright.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage loginPage;

        public LoginSteps(IPage page)
        {
            loginPage = new LoginPage(page);
        }

        [Given(@"""(.*)"" page is open")]
        public async Task GivenPageIsOpen(string urlParameter)
        {
            await loginPage.OpenAsync(urlParameter);
        }

        [Given(@"UserName ""(.*)"" is entered")]
        public async Task GivenUserNameIsEntered(string userName)
        {
            await loginPage.EnterUsernameAsync(userName);
        }

        [Given(@"Password ""(.*)"" is entered")]
        public async Task GivenPasswordIsEntered(string password)
        {
            await loginPage.EnterPasswordAsync(password);
        }

        [Given(@"User clicks on New User button")]
        public async Task GivenUserClicksOnNewUserButton()
        {
            await loginPage.ClickNewUserButtonAsync();
        }

        [When(@"User fills ""(.*)"", ""(.*)"", ""(.*)"" and ""(.*)""")]
        public async Task WhenUserFillsAnd(string firstName, string lastName, string userName, string password)
        {
            await loginPage.FillNewUserDataAsync(firstName, lastName, userName, password);
        }

        [When(@"User clicks recaptcha checkbox")]
        public async Task WhenUserClicksRecaptchaCheckbox()
        {
            await loginPage.ClickRecaptchaCheckBoxAsync();
        }

        [When(@"User clicks on Register button")]
        public async Task WhenUserClicksOnRegisterButton()
        {
            await loginPage.ClickRegisterButtonAsync();
        }

        [When(@"User clicks on Login button")]
        public async Task WhenUserClicksOnLoginButton()
        {
            await loginPage.ClickLoginButtonAsync();
        }

        [Then(@"User should be redirected to the login page")]
        public async Task ThenUserShouldBeRedirectedToTheLoginPage()
        {
            // Assert.AreEqual("https://your-login-page-url.com/login", await loginPage.GetUrlAsync());
        }

        [Then(@"UserName ""(.*)"" is entered")]
        public async Task ThenUserNameIsEntered(string userName)
        {
            await loginPage.EnterUsernameAsync(userName);
        }

        [Then(@"Password ""(.*)"" is entered")]
        public async Task ThenPasswordIsEntered(string password)
        {
            await loginPage.EnterPasswordAsync(password);
        }

        [Then(@"User clicks on Login button")]
        public async Task ThenUserClicksOnLoginButton()
        {
            await loginPage.ClickLoginButtonAsync();
        }

        [Then(@"User verifies required fields")]
        public async Task ThenUserVerifiesRequiredFields()
        {
            await loginPage.VerifyRequiredFieldsAsync();
        }

        [Then(@"User verifies username required field")]
        public async Task ThenUserVerifiesUserNameRequiredField()
        {
            await loginPage.VerifyUserNameRequiredFieldAsync();
        }

        [Then(@"User verifies password required field")]
        public async Task ThenUserVerifiesPasswordRequiredField()
        {
            await loginPage.VerifyPasswordRequiredFieldAsync();
        }

        [Then(@"User shows ""([^""]*)"" message")]
        public async Task ThenUserShowsMessage(string message)
        {
            await loginPage.VerifyMessageAsync(message);
        }
    }
}
