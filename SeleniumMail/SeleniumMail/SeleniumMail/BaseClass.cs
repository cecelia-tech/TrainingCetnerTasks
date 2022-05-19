using OpenQA.Selenium;

namespace SeleniumMail;

internal abstract class BaseClass
{
    protected const string SEND_TO_LOCATOR = "suggest-to";
    protected const string SUBJECT_LOCATOR = "//*[@id='subject']";
    protected const string EMAIL_BODY_LOCATOR = "//iframe[contains(@title, 'message')]";
    protected const string EMAIL_BODY_FRAMEWORK = "//body[contains(@class, 'cke_editable')]";
    protected const string SEND_BUTTON_LOCATOR = "//button[.//span[@class='inner-text']]";
    protected const string EMAIL_INPUT_LOCATOR = "//*[@id='imapuser']";
    protected const string PASSWORD_INPUT_LOCATOR = "//*[@id='pass']";
    protected const string SIGNIN_BUTTON_NEXT_LOCATOR = "//*[@id='btn_sign-in']";
    protected const string SIGNOUT_BUTTON_LOCATOR = "//*[@id='side-trigger']";
    private const string SIGNOUT2_BUTTON_LOCATOR = "//a[@title='Išeiti']";

    internal IWebDriver _driver;
    
    public BaseClass(IWebDriver driver)
    {
        _driver = driver;
    }

    public virtual void SetSendTo(string email)
    {
        var sendToInput = GetElementById(SEND_TO_LOCATOR);
        sendToInput.Clear();
        sendToInput.Click();
        sendToInput.SendKeys(email);
    }

    public void SetSubject(string subject)
    {
        var subjectInput = GetElementByXPath(SUBJECT_LOCATOR);
        subjectInput.Clear();
        subjectInput.Click();
        subjectInput.SendKeys(subject);
    }

    public void SetMessageContent(string emailBody)
    {
        var emailInput = GetElementByXPath(EMAIL_BODY_LOCATOR);
        _driver.SwitchTo().Frame(emailInput);
        var frame = GetElementByXPath(EMAIL_BODY_FRAMEWORK);
        frame.SendKeys(emailBody);
        _driver.SwitchTo().DefaultContent();
    }

    public void PressSend()
    {
        GetElementByXPath(SEND_BUTTON_LOCATOR).Click();
    }

    public bool CheckIfEmailSent()
    {
        return _driver.Title.Contains(String.Format("Pranešimo struktūra"));
    }

    public void SignIn(string email, string password)
    {
        var emailInput = GetElementByXPath(EMAIL_INPUT_LOCATOR);
        emailInput.Clear();
        emailInput.Click();
        emailInput.SendKeys(email);
        var passwordInput = GetElementByXPath(PASSWORD_INPUT_LOCATOR);
        passwordInput.Clear();
        passwordInput.Click();
        passwordInput.SendKeys(password);
        GetElementByXPath(SIGNIN_BUTTON_NEXT_LOCATOR).Click();
    }

    public void SignOut()
    {
        GetElementByXPath(SIGNOUT_BUTTON_LOCATOR).Click();
        GetElementByXPath(SIGNOUT2_BUTTON_LOCATOR).Click();
    }
    public IWebElement GetElementByXPath(string path)
    {
        IWebElement? webElement = null;

        while (webElement == null)
        {
            try
            {
                webElement = _driver.FindElement(By.XPath(path));
            }
            catch (Exception)
            {
                Thread.Sleep(1000);
            }
        }
        return webElement;
    }

    public IWebElement GetElementById(string id)
    {
        IWebElement? webElement = null;

        while (webElement == null)
        {
            try
            {
                webElement = _driver.FindElement(By.Id(id));
            }
            catch (Exception)
            {
                Thread.Sleep(1000);
            }
        }
        return webElement;
    }
}
