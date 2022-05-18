using OpenQA.Selenium;

namespace SeleniumMail;

internal class BaseClass
{
    internal IWebDriver _driver;
    public BaseClass(IWebDriver driver)
    {
        _driver = driver;
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
