using OpenQA.Selenium;

namespace SeleniumMail;

internal class InboxNewEmail : BaseClass
{
    const string SEND_TO_LOCATOR = "suggest-to";
    const string SEND_TO_EMAIL = "jcecelia72@gmail.com";
    const string SUBJECT_LOCATOR = "//*[@id='subject']";
    const string EMAIL_SUBJECT = "Test";
    const string EMAIL_BODY_LOCATOR = "//iframe[contains(@title, 'message')]";
    const string EMAIL_BODY_FRAMEWORK = "//body[contains(@class, 'cke_editable')]";
    const string EMAIL_BODY = "Sending a test email";
    const string SEND_BUTTON_LOCATOR = "//button[.//span[@class='inner-text']]";
    //const string SEND_BUTTON_LOCATOR = "//td[@class='article']";

    //<button data-action="eml-send" data-test="toolbar-send" type="button" class="Button-sc-3zooqt-0 jtychv"><svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 512 512" class="inx-fa-icon" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg"><path d="M440 6.5L24 246.4c-34.4 19.9-31.1 70.8 5.7 85.9L144 379.6V464c0 46.4 59.2 65.5 86.6 28.6l43.8-59.1 111.9 46.2c5.9 2.4 12.1 3.6 18.3 3.6 8.2 0 16.3-2.1 23.6-6.2 12.8-7.2 21.6-20 23.9-34.5l59.4-387.2c6.1-40.1-36.9-68.8-71.5-48.9zM192 464v-64.6l36.6 15.1L192 464zm212.6-28.7l-153.8-63.5L391 169.5c10.7-15.5-9.5-33.5-23.7-21.2L155.8 332.6 48 288 464 48l-59.4 387.3z"></path></svg><span class="inner-text">Siųsti žinutę</span></button>
    //<div id="eml-toolbar-container"><div class="Toolbar-sc-1xt08o9-1 dyRZoR"><div class="ButtonGroup-sc-1xt08o9-0 DldWV"><button data-action="eml-cancel" data-test="toolbar-back" type="button" class="Button-sc-3zooqt-0 bViSGI"><svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 320 512" class="inx-fa-icon" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg"><path d="M34.52 239.03L228.87 44.69c9.37-9.37 24.57-9.37 33.94 0l22.67 22.67c9.36 9.36 9.37 24.52.04 33.9L131.49 256l154.02 154.75c9.34 9.38 9.32 24.54-.04 33.9l-22.67 22.67c-9.37 9.37-24.57 9.37-33.94 0L34.52 272.97c-9.37-9.37-9.37-24.57 0-33.94z"></path></svg></button><button data-action="eml-send" data-test="toolbar-send" type="button" class="Button-sc-3zooqt-0 jtychv"><svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 512 512" class="inx-fa-icon" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg"><path d="M440 6.5L24 246.4c-34.4 19.9-31.1 70.8 5.7 85.9L144 379.6V464c0 46.4 59.2 65.5 86.6 28.6l43.8-59.1 111.9 46.2c5.9 2.4 12.1 3.6 18.3 3.6 8.2 0 16.3-2.1 23.6-6.2 12.8-7.2 21.6-20 23.9-34.5l59.4-387.2c6.1-40.1-36.9-68.8-71.5-48.9zM192 464v-64.6l36.6 15.1L192 464zm212.6-28.7l-153.8-63.5L391 169.5c10.7-15.5-9.5-33.5-23.7-21.2L155.8 332.6 48 288 464 48l-59.4 387.3z"></path></svg><span class="inner-text">Siųsti žinutę</span></button><button data-action="eml-save" data-test="toolbar-save" type="button" class="Button-sc-3zooqt-0 bViSGI"><svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 448 512" class="inx-fa-icon" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg"><path d="M433.941 129.941l-83.882-83.882A48 48 0 0 0 316.118 32H48C21.49 32 0 53.49 0 80v352c0 26.51 21.49 48 48 48h352c26.51 0 48-21.49 48-48V163.882a48 48 0 0 0-14.059-33.941zM272 80v80H144V80h128zm122 352H54a6 6 0 0 1-6-6V86a6 6 0 0 1 6-6h42v104c0 13.255 10.745 24 24 24h176c13.255 0 24-10.745 24-24V83.882l78.243 78.243a6 6 0 0 1 1.757 4.243V426a6 6 0 0 1-6 6zM224 232c-48.523 0-88 39.477-88 88s39.477 88 88 88 88-39.477 88-88-39.477-88-88-88zm0 128c-22.056 0-40-17.944-40-40s17.944-40 40-40 40 17.944 40 40-17.944 40-40 40z"></path></svg><span class="inner-text">Išsaugoti</span></button><div data-test="dropdown" class="Button-sc-3zooqt-0 bViSGI" aria-expanded="false"><svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 192 512" class="inx-fa-icon" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg"><path d="M96 184c39.8 0 72 32.2 72 72s-32.2 72-72 72-72-32.2-72-72 32.2-72 72-72zM24 80c0 39.8 32.2 72 72 72s72-32.2 72-72S135.8 8 96 8 24 40.2 24 80zm0 352c0 39.8 32.2 72 72 72s72-32.2 72-72-32.2-72-72-72-72 32.2-72 72z"></path></svg></div></div><div class="ButtonGroup-sc-1xt08o9-0 DldWV"><button data-action="eml-cancel" data-test="toolbar-cancel" type="button" class="Button-sc-3zooqt-0 bViSGI" style="margin-right: 0px;"><svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 352 512" class="inx-fa-icon" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg"><path d="M242.72 256l100.07-100.07c12.28-12.28 12.28-32.19 0-44.48l-22.24-22.24c-12.28-12.28-32.19-12.28-44.48 0L176 189.28 75.93 89.21c-12.28-12.28-32.19-12.28-44.48 0L9.21 111.45c-12.28 12.28-12.28 32.19 0 44.48L109.28 256 9.21 356.07c-12.28 12.28-12.28 32.19 0 44.48l22.24 22.24c12.28 12.28 32.2 12.28 44.48 0L176 322.72l100.07 100.07c12.28 12.28 32.2 12.28 44.48 0l22.24-22.24c12.28-12.28 12.28-32.19 0-44.48L242.72 256z"></path></svg></button></div></div></div>
    //<span class="inner-text">Siųsti žinutę</span>
    //*[@id="eml-toolbar-container"]/div/div[1]/button[2]

    //jcecelia72@gmail.com
    //KadIrKas_Bebutu63!

    public InboxNewEmail(IWebDriver driver) : base(driver)
    {
    }

    public void SetSendTo()
    {
        var sendToInput = GetElementById(SEND_TO_LOCATOR);
        sendToInput.Click();
        sendToInput.SendKeys(SEND_TO_EMAIL);
    }

    public void SetSubject()
    {
        var sendToInput = GetElementByXPath(SUBJECT_LOCATOR);
        sendToInput.Click();
        sendToInput.SendKeys(EMAIL_SUBJECT);
    }

    public void SetMessageContent()
    {
        var emailInput = GetElementByXPath(EMAIL_BODY_LOCATOR);
        _driver.SwitchTo().Frame(emailInput);
        var frame = GetElementByXPath(EMAIL_BODY_FRAMEWORK);
        frame.SendKeys(EMAIL_BODY);
        _driver.SwitchTo().DefaultContent();
    }

    public void PressSend()
    {
        GetElementByXPath(SEND_BUTTON_LOCATOR).Click();
    }

    public bool CheckIfEmailSent()
    {
        return _driver.Title.Contains(String.Format("Pranešimo struktūra"));
    }
}
