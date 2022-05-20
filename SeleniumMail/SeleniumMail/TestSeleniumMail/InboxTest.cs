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
        InboxNewEmail newEmail = new InboxNewEmail(_driver);
        newEmail.SetSendTo(newEmail.SEND_TO_EMAIL);
        newEmail.SetSubject(newEmail.EMAIL_SUBJECT);
        newEmail.SetMessageContent(newEmail.EMAIL_BODY);
        newEmail.PressSend();
        Thread.Sleep(2000);
        Assert.IsTrue(newEmail.CheckIfEmailSent());
        newEmail.SignOut();
    }

    [TestMethod]
    public void TestReceivedEmail()
    {
        ReceivedEmailSignInPage signInpage = new ReceivedEmailSignInPage(_driver);
      //  signInpage.SignIn(signInpage.EMAIL, signInpage.PASSWORD);
        Thread.Sleep(1000);
        InboxReceivedEmail inboxReceivedEmail = new InboxReceivedEmail(_driver);

        Assert.IsTrue(inboxReceivedEmail.CheckIfEmailReceived());
    }

    [TestMethod]
    public void TestReplyReceivedEmail()
    {
        SignInPage signInpage = new SignInPage(_driver);
        string email = "automationtest@inbox.lt";
        string password = "automationtest954!";
        signInpage.SignIn(email, password);

        Thread.Sleep(1000);
        InboxReceivedEmail inboxReceivedEmail = new InboxReceivedEmail(_driver);
        inboxReceivedEmail.ClickReceivedEmail();
        ReceivedEmailPage receivedEmailPage = new ReceivedEmailPage(_driver);
        receivedEmailPage.PressReply();
        ReplyEmailPage replyEmailPage = new ReplyEmailPage(_driver);
        replyEmailPage.SetMessageContent(replyEmailPage.REPLY_MESSAGE);
        replyEmailPage.PressSend();
        Thread.Sleep(1000);
        replyEmailPage.SignOut();
    }
}
