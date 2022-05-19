using OpenQA.Selenium;

namespace SeleniumMail.ReceivedEmail;

internal class InboxReceivedEmail : BaseClass
{
    internal readonly string RECEIVED_EMAIL_LOCATOR = "//span[@title='cecelia@inbox.lt']";

    public InboxReceivedEmail(IWebDriver driver) : base(driver)
    {
    }

    public bool CheckIfEmailReceived()
    {
        GetElementByXPath(RECEIVED_EMAIL_LOCATOR);

        return true;
    }

    public void ClickReceivedEmail()
    {
        GetElementByXPath(RECEIVED_EMAIL_LOCATOR).Click();
    }
}
