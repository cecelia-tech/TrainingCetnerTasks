using OpenQA.Selenium;

namespace SeleniumMail.ReceivedEmail;

internal class ReplyEmailPage : BaseClass
{
    internal readonly string REPLY_MESSAGE = "Replying to a test email.";
    public ReplyEmailPage(IWebDriver driver) : base(driver)
    {
    }

    
}
