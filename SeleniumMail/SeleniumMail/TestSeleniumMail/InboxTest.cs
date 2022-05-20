namespace TestSeleniumMail;

[TestClass]
public class InboxTest : TestBaseClass
{
    [TestMethod]
    public void TestNewEmail()
    {
        SignInPage signInpage = new SignInPage(_driver);
        string email = "cecelia@inbox.lt";
        string password = "piXmur-2wynno-potfoq";
        signInpage.SignIn(email, password);

        InboxHomePage homepage = new InboxHomePage(_driver);
        homepage.PressNewEmail();

        NewEmail newEmail = new NewEmail(_driver);
        string sendToEmail = "automationtest@inbox.lt";
        string emailSubject = "Test";
        string emailContent = "Sending a test email";
        newEmail.SetSendTo(sendToEmail);
        newEmail.SetSubject(emailSubject);
        newEmail.SetMessageContent(emailContent);
        newEmail.PressSend();

        Assert.IsTrue(newEmail.CheckIfEmailSent());

        newEmail.SignOut();
    }

    [TestMethod]
    public void TestReceivedEmail()
    {
        SignInPage signInpage = new SignInPage(_driver);
        string email = "automationtest@inbox.lt";
        string password = "automationtest954!";
        signInpage.SignIn(email, password);

        InboxHomePage inboxReceivedEmail = new InboxHomePage(_driver);

        Assert.IsTrue(inboxReceivedEmail.CheckIfEmailReceived());
    }

    [TestMethod]
    public void TestReplyReceivedEmail()
    {
        SignInPage signInpage = new SignInPage(_driver);
        string email = "automationtest@inbox.lt";
        string password = "automationtest954!";
        signInpage.SignIn(email, password);

        InboxHomePage inboxReceivedEmail = new InboxHomePage(_driver);
        inboxReceivedEmail.ClickReceivedEmail();

        ReceivedEmailPage receivedEmailPage = new ReceivedEmailPage(_driver);
        receivedEmailPage.PressReply();

        NewEmail replyEmailPage = new NewEmail(_driver);
        string replyEmailContent = "Replying to a test email.";
        replyEmailPage.SetMessageContent(replyEmailContent);
        replyEmailPage.PressSend();

        Assert.IsTrue( replyEmailPage.CheckIfEmailSent());

        replyEmailPage.SignOut();
    }
}
