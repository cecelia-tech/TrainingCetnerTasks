

namespace TestSeleniumMail;

[TestClass]
public class InboxTest
{
    IWebDriver _driver;

    [TestInitialize]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Url = "https://www.inbox.lt/";
        _driver.Manage().Window.Maximize();
    }
    
    [TestMethod]
    public void TestSignInPage()
    {
        InboxSignInPage signInpage = new InboxSignInPage(_driver);
        signInpage.SignIn();
        InboxHomePage homepage = new InboxHomePage(_driver);
        homepage.PressNewEmail();
        InboxNewEmail newEmail = new InboxNewEmail(_driver);
        newEmail.SetSendTo();
        newEmail.SetSubject();
        newEmail.SetMessageContent();
        
        newEmail.PressSend();
        Thread.Sleep(1000);
        Assert.IsTrue(newEmail.CheckIfEmailSent());
    }

    [TestCleanup]
    public void CleanUp()
    {
        _driver.Close();
        _driver.Dispose();
    }
}
