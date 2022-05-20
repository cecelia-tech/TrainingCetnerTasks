using OpenQA.Selenium;

namespace SeleniumMail;

internal abstract class BaseClass
{
    const string SIGNOUT_BUTTON_LOCATOR = "//*[@id='side-trigger']";
    const string SIGNOUT2_BUTTON_LOCATOR = "//a[@title='Išeiti']";

    internal IWebDriver _driver;
    
    public BaseClass(IWebDriver driver)
    {
        _driver = driver;
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
