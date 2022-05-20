namespace SeleniumMail;

internal class ReceivedEmailPage : BaseClass
{
    const string REPLY_BUTTON_LOCATOR = "//button[.//*[text()='Atsakyti']]";

    public ReceivedEmailPage(IWebDriver driver) : base(driver)
    {
    }

    internal void PressReply()
    {
        GetElementByXPath(REPLY_BUTTON_LOCATOR).Click();
    }
}
