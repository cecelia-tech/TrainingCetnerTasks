using OpenQA.Selenium;

namespace SeleniumMail;

internal class InboxNewEmail : BaseClass
{
    internal readonly string SEND_TO_EMAIL = "automationtest@inbox.lt";
    public readonly string EMAIL_SUBJECT = "Test";
    public readonly string EMAIL_BODY = "Sending a test email";

    public InboxNewEmail(IWebDriver driver) : base(driver)
    {
    }

}
