namespace SeleniumMail;

internal class SignInPage : BaseClass
{
    const string PASSWORD_INPUT_LOCATOR = "//*[@id='pass']";
    const string EMAIL_INPUT_LOCATOR = "//*[@id='imapuser']";
    const string SIGNIN_BUTTON_LOCATOR = "//*[@id='btn_sign-in']";

    public SignInPage(IWebDriver driver) : base(driver)
    {
    }

    internal void SignIn(string email, string password)
    {
        var emailInput = GetElementByXPath(EMAIL_INPUT_LOCATOR);
        emailInput.Clear();
        emailInput.SendKeys(email);
        var passwordInput = GetElementByXPath(PASSWORD_INPUT_LOCATOR);
        passwordInput.Clear();
        passwordInput.SendKeys(password);
        GetElementByXPath(SIGNIN_BUTTON_LOCATOR).Click();
    }
}
 