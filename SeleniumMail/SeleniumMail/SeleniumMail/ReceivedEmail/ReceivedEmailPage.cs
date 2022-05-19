using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMail.ReceivedEmail;

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
