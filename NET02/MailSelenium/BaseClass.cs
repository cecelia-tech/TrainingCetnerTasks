using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSelenium;

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
}
