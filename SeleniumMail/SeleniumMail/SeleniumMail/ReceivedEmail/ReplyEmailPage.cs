using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMail.ReceivedEmail;

internal class ReplyEmailPage : BaseClass
{
    internal readonly string REPLY_MESSAGE = "Replying to a test email.";
    public ReplyEmailPage(IWebDriver driver) : base(driver)
    {
    }

    
}
