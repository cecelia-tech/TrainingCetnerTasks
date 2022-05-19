namespace TestSeleniumMail;

[TestClass]
public class GmailTest : TestBaseClass
{
    [TestMethod]
    public void TestPressSignIn()
    {
        _driver.Url = "https://www.google.com/intl/en/gmail/about/";
        _driver.Manage().Window.Maximize();
        GmailFrontPage gmailFrontPage = new GmailFrontPage(_driver);
        gmailFrontPage.PressSignInButton();
        GmailLogInPage gmailLogInPage = new GmailLogInPage(_driver);
        gmailLogInPage.SetEmail();
        gmailLogInPage.SetBackupEmail();
        gmailLogInPage.SetNameLastName();
    }
}
