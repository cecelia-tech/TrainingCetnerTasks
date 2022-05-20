using OpenQA.Selenium;

namespace SeleniumMail;

internal class InboxHomePage : BaseClass
{
    internal const string NEW_EMAIL_LOCATOR = "//*[@id='mail-menu_li_compose']/a";
    internal const string RECEIVED_EMAIL_LOCATOR = "//span[@title='cecelia@inbox.lt']";

    public InboxHomePage(IWebDriver driver) : base(driver)
    {
    }

    public void PressNewEmail()
    {
        GetElementByXPath(NEW_EMAIL_LOCATOR).Click();
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
