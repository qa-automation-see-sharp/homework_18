using System;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.Browser;

namespace Tests.Utils.Swd.PageObjects;

public class RadioButtonPage : BasePage.BasePage
{
    public string Url => "https://demoqa.com/radio-button";

    [FindBy(XPath = "//h1[contains(text(),\"Radio Button\")]")]
    public WebElement? Title { get; set; }

    [FindBy(XPath = "//label[@for='yesRadio']")]
    public Button? YesRadio { get; set; }

    [FindBy(XPath = "//label[@for='impressiveRadio']")]
    public Button? Impressive { get; set; }

    [FindBy(XPath = "//label[@class='custom-control-label disabled' and @for='noRadio']")]
    public Button? NoButton { get; set; }

    [FindBy(ClassName = "mt-3")]
    public WebElement? Output { get; set; }

    [FindBy(ClassName = "mb-3")]
    public WebElement? QuetionText { get; set; }

    public RadioButtonPage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }

    public RadioButtonPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }

}