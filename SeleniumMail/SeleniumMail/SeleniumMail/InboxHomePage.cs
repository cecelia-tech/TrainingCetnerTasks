using OpenQA.Selenium;

namespace SeleniumMail;

internal class InboxHomePage : BaseClass
{
    const string NEW_EMAIL_LOCATOR = "//*[@id='mail-menu_li_compose']/a";

    public InboxHomePage(IWebDriver driver) : base(driver)
    {
    }

    public void PressNewEmail()
    {
        GetElementByXPath(NEW_EMAIL_LOCATOR).Click();
    }

    public void CheckReceivedEmail()
    {
        GetElementByXPath(NEW_EMAIL_LOCATOR).Click();
    }
}
