namespace TestSeleniumMail;

[TestClass]
public class InboxTest : TestBaseClass
{
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

}
