using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMail;

internal class InboxSignInPage : BaseClass
{
    const string EMAIL_INPUT_LOCATOR = "//*[@id='imapuser']";
    const string PASSWORD_INPUT_LOCATOR = "//*[@id='pass']";
    const string SIGNIN_BUTTON_NEXT_LOCATOR = "//*[@id='btn_sign-in']";
    const string EMAIL = "cecelia@inbox.lt";
    const string PASSWORD = "piXmur-2wynno-potfoq";
    
    public InboxSignInPage(IWebDriver driver) : base(driver)
    {
    }

    public void SignIn()
    {
        var emailInput = GetElementByXPath(EMAIL_INPUT_LOCATOR);
        emailInput.Click();
        emailInput.SendKeys(EMAIL);
        var passwordInput = GetElementByXPath(PASSWORD_INPUT_LOCATOR);
        passwordInput.Click();
        passwordInput.SendKeys(PASSWORD);
        GetElementByXPath(SIGNIN_BUTTON_NEXT_LOCATOR).Click();
    }

}
