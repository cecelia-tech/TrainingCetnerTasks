using OpenQA.Selenium;
namespace SeleniumMail.ReceivedEmail;

internal class ReceivedEmailSignInPage : BaseClass
{
    internal readonly string EMAIL = "automationtest@inbox.lt";
    internal readonly string PASSWORD = "automationtest954!";

    public ReceivedEmailSignInPage(IWebDriver driver) : base(driver)
    {
    }
}
