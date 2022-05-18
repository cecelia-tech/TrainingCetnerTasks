namespace TestSeleniumMail;

[TestClass]
public class UnitTest1
{
    IWebDriver _driver;

    [TestInitialize]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Url = "https://www.google.com/maps";
        _driver.Manage().Window.Maximize();
    }

    [TestMethod]
    public void TestMethod1()
    {
    }

    [TestCleanup]
    public void CleanUp()
    {
        _driver.Close();
        _driver.Dispose();
    }
}
