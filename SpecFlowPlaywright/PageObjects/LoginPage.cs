using Microsoft.Playwright;
using NUnit.Framework;
using SpecFlowPlaywright.PageObjects;

namespace SpecFlowPlaywright.PageObjects
{
    public class LoginPage : BasePage
    {
        private readonly IPage _page;

        public LoginPage(IPage page) : base(page)
        {
            _page = page;
        }

        #region WebElements

        private ILocator UsernameField => _page.Locator("#userName");
        private ILocator FirstnameField => _page.Locator("#firstname");
        private ILocator LastnameField => _page.Locator("#lastname");
        private ILocator RegisterButton => _page.Locator("#register");
        private ILocator PasswordField => _page.Locator("#password");
        private ILocator ErrorMessage => _page.Locator("#name");
        private ILocator LoginButton => _page.Locator("#login");
        private ILocator NewUserButton => _page.Locator("#newUser");
        private ILocator BackToLoginButton => _page.Locator("#gotologin");

        #endregion

        public async Task NewUserAsync(string firstname, string lastname, string username, string password)
        {
            await FirstnameField.FillAsync(firstname);
            await LastnameField.FillAsync(lastname);
            await UsernameField.FillAsync(username);
            await PasswordField.FillAsync(password);

            var recaptchaFrame = _page.FrameLocator("//iframe[@title='reCAPTCHA']");
            var recaptchaCheckbox = recaptchaFrame.Locator("#recaptcha-anchor");
            await recaptchaCheckbox.ClickAsync();

            await RegisterButton.ClickAsync();
        }

        public async Task FillNewUserDataAsync(string firstname, string lastname, string username, string password)
        {
            await FirstnameField.FillAsync(firstname);
            await LastnameField.FillAsync(lastname);
            await UsernameField.FillAsync(username);
            await PasswordField.FillAsync(password);
        }

        public async Task EnterUsernameAsync(string username)
        {
            await UsernameField.FillAsync(username);
        }

        public async Task EnterPasswordAsync(string password)
        {
            await PasswordField.FillAsync(password);
        }

        public async Task VerifyMessageAsync(string message)
        {
            Assert.IsTrue((await ErrorMessage.TextContentAsync()).Equals(message));
        }

        public async Task VerifyRequiredFieldAsync(ILocator field)
        {
            Assert.IsTrue((await field.GetAttributeAsync("class")).Contains("is-invalid"));
        }

        public async Task VerifyRequiredFieldsAsync(params ILocator[] fields)
        {
            foreach (var field in fields)
            {
                await VerifyRequiredFieldAsync(field);
            }
        }

        public async Task VerifyRequiredFieldsAsync()
        {
            await VerifyRequiredFieldsAsync(UsernameField, PasswordField);
        }

        public async Task VerifyUserNameRequiredFieldAsync()
        {
            await VerifyRequiredFieldsAsync(UsernameField);
        }

        public async Task VerifyPasswordRequiredFieldAsync()
        {
            await VerifyRequiredFieldsAsync(PasswordField);
        }

        public async Task ClickLoginButtonAsync()
        {
            await LoginButton.ClickAsync();
        }

        public async Task ClickRecaptchaCheckBoxAsync()
        {
            var recaptchaFrame = _page.FrameLocator("//iframe[@title='reCAPTCHA']");
            var recaptchaCheckbox = recaptchaFrame.Locator("#recaptcha-anchor");
            await recaptchaCheckbox.ClickAsync();
        }

        public async Task ClickRegisterButtonAsync()
        {
            await RegisterButton.ClickAsync();
        }

        public async Task ClickNewUserButtonAsync()
        {
            await NewUserButton.ClickAsync();
        }

        public async Task ClickBackToLoginButtonAsync()
        {
            await BackToLoginButton.ClickAsync();
        }

        public async Task<bool> IsWelcomeMessageDisplayedAsync()
        {
            return await _page.Locator("#welcomeMessage").IsVisibleAsync();
        }
    }
}
