using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMail.Gmail
{
    internal class GmailFrontPage : BaseClass
    {
        const string SINGIN_BUTTON_LOCATOR = "//a[contains(@*, 'sign in')]";

        public GmailFrontPage(IWebDriver driver) : base(driver)
        {
        }

        public void PressSignInButton()
        {
            GetElementByXPath(SINGIN_BUTTON_LOCATOR).Click();
        }
    }
}
