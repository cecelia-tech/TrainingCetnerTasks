﻿namespace SeleniumMail;

internal class NewEmailPage : BaseClass
{
    const string SEND_TO_LOCATOR = "suggest-to";
    const string SUBJECT_LOCATOR = "//*[@id='subject']";
    const string EMAIL_BODY_LOCATOR = "//iframe[contains(@title, 'message')]";
    const string EMAIL_BODY_FRAMEWORK = "//body[contains(@class, 'cke_editable')]";
    const string SEND_BUTTON_LOCATOR = "//button[.//span[@class='inner-text']]";
    const string EMAIL_SENT_ALERT = "//div[contains(., 'sėkmingai išsiųstas')]";

    public NewEmailPage(IWebDriver driver) : base(driver)
    {
    }

    internal virtual void SetSendTo(string email)
    {
        var sendToInput = GetElementById(SEND_TO_LOCATOR);
        sendToInput.Clear();
        sendToInput.SendKeys(email);
    }

    internal void SetSubject(string subject)
    {
        var subjectInput = GetElementByXPath(SUBJECT_LOCATOR);
        subjectInput.Clear();
        subjectInput.SendKeys(subject);
    }

    internal void SetMessageContent(string emailBody)
    {
        var emailInput = GetElementByXPath(EMAIL_BODY_LOCATOR);
        _driver.SwitchTo().Frame(emailInput);
        var frame = GetElementByXPath(EMAIL_BODY_FRAMEWORK);
        frame.SendKeys(emailBody);
        _driver.SwitchTo().DefaultContent();
    }

    internal void PressSend()
    {
        GetElementByXPath(SEND_BUTTON_LOCATOR).Click();
    }

    public bool CheckIfEmailSent()
    {
        var emailSentAlert = GetElementByXPath(EMAIL_SENT_ALERT);

        return emailSentAlert.Text.Contains(string.Format("sėkmingai išsiųstas"));
    }

}
