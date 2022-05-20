using OpenQA.Selenium;

namespace SeleniumMail;

internal class SignInPage : BaseClass
{
    protected const string PASSWORD_INPUT_LOCATOR = "//*[@id='pass']";
    protected const string EMAIL_INPUT_LOCATOR = "//*[@id='imapuser']";

    public SignInPage(IWebDriver driver) : base(driver)
    {
    }

    public void SignIn(string email, string password)
    {
        var emailInput = GetElementByXPath(EMAIL_INPUT_LOCATOR);
        emailInput.Clear();
        emailInput.SendKeys(email);
        var passwordInput = GetElementByXPath(PASSWORD_INPUT_LOCATOR);
        passwordInput.Clear();
        passwordInput.SendKeys(password);
        GetElementByXPath(SIGNIN_BUTTON_NEXT_LOCATOR).Click();
    }
}
 