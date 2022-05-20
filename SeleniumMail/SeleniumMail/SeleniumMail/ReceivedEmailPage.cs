using OpenQA.Selenium;

namespace SeleniumMail;

internal class ReceivedEmailPage : BaseClass
{
    internal readonly string REPLY_BUTTON_LOCATOR = "//button[.//*[text()='Atsakyti']]";
    public ReceivedEmailPage(IWebDriver driver) : base(driver)
    {
    }

    public void PressReply()
    {
        GetElementByXPath(REPLY_BUTTON_LOCATOR).Click();
    }
}
