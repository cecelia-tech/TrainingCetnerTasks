using OpenQA.Selenium;

namespace SeleniumMail.Gmail;

internal class GmailLogInPage : BaseClass
{



    const string EMAIL_INPUT_LOCATOR3 = "//input[@type='email']";
    const string EMAIL = "jcecelia72@gmail.com";
    const string BACKUP_EMAIL = "cecelia@inbox.lt";
    const string PASSWORD = "KadIrKas_Bebutu63!";
    const string NEXT_BUTTON_LOCATOR = "//button[@type = 'button']";
    const string NAME = "Cecelia";
    const string LASTNAME = "Johnson";
    const string NAME_INPUT_LOCATOR = "firstName";
    const string LASTNAME_INPUT_LOCATOR = "lastName";

    //<input type="text" class="whsOnd zHQkBf" jsname="YPqjbf" autocomplete="off" spellcheck="false" tabindex="0" aria-label="Pavardė" name="lastName" value="" autocapitalize="sentences" id="lastName" data-initial-value="">

    public GmailLogInPage(IWebDriver driver) : base(driver)
    {
    }

    public void SetEmail()
    {
        var emailInput = GetElementByXPath(EMAIL_INPUT_LOCATOR);
        emailInput.Click();
        emailInput.SendKeys(EMAIL);
        Thread.Sleep(1000);
        GetElementByXPath(NEXT_BUTTON_LOCATOR).Click();
    }

    public void SetBackupEmail()
    {
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        var backupEmailInput = GetElementByXPath(EMAIL_INPUT_LOCATOR);
        Thread.Sleep(1000);
        backupEmailInput.Click();
        Thread.Sleep(1000);
        backupEmailInput.SendKeys(BACKUP_EMAIL);
        Thread.Sleep(2000);
        GetElementByXPath(NEXT_BUTTON_LOCATOR).Click();
    }

    public void SetNameLastName()
    {
        var nameInput = GetElementById(NAME_INPUT_LOCATOR);
        Thread.Sleep(1000);
        nameInput.Click();
        Thread.Sleep(1000);
        nameInput.SendKeys(NAME);
        Thread.Sleep(1000);
        var lastNameInput = GetElementById(LASTNAME_INPUT_LOCATOR);
        Thread.Sleep(1000);
        lastNameInput.Click();
        Thread.Sleep(1000);
        lastNameInput.SendKeys(LASTNAME);
        Thread.Sleep(2000);
        GetElementByXPath(NEXT_BUTTON_LOCATOR).Click();
    }
}
