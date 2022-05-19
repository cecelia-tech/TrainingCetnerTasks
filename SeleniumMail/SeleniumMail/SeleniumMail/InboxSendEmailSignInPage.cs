using OpenQA.Selenium;

namespace SeleniumMail;

internal class InboxSendEmailSignInPage : BaseClass
{
    internal readonly string EMAIL = "cecelia@inbox.lt";
    internal readonly string PASSWORD = "piXmur-2wynno-potfoq";
    
    public InboxSendEmailSignInPage(IWebDriver driver) : base(driver)
    {
    }
}
 