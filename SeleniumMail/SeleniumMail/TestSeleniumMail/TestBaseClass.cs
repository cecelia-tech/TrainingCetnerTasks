namespace TestSeleniumMail;

[TestClass]
public class TestBaseClass
{
    protected IWebDriver _driver;

    [TestInitialize]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Url = "https://www.inbox.lt/";
        _driver.Manage().Window.Maximize();
    }

    [TestCleanup]
    public void CleanUp()
    {
        _driver.Close();
        _driver.Dispose();
    }
}
