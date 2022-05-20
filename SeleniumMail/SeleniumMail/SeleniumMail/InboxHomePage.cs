namespace SeleniumMail;

internal class InboxHomePage : BaseClass
{
    const string NEW_EMAIL_LOCATOR = "//*[@id='mail-menu_li_compose']/a";
    const string RECEIVED_EMAIL_LOCATOR = "//span[@title='Test']";

    public InboxHomePage(IWebDriver driver) : base(driver)
    {
    }

    internal void PressNewEmail()
    {
        GetElementByXPath(NEW_EMAIL_LOCATOR).Click();
    }

    internal bool CheckIfEmailReceived()
    {
        GetElementByXPath(RECEIVED_EMAIL_LOCATOR);

        return true;
    }

    internal void ClickReceivedEmail()
    {
        GetElementByXPath(RECEIVED_EMAIL_LOCATOR).Click();
    }
}
