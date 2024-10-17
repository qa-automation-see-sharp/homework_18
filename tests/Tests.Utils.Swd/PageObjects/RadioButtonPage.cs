using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.Browser;

namespace Tests.Utils.Swd.PageObjects;

public class RadioButtonPage: BasePage.BasePage
{
    public string Url => "https://demoqa.com/radio-button";
    
    [FindBy(XPath = "//h1[contains(text(),\"Radio Button\")]")]
    private WebElement? RadioButtonTitle { get; set; }
    
    [FindBy(CssSelector = "[for='yesRadio']")]
    private Button? YesRadioButton { get; set; }
    
    [FindBy(CssSelector = "[for='impressiveRadio']")]
    private Button? ImpressiveRadioButton { get; set; }
    
    [FindBy(CssSelector = "[for='noRadio']")]
    private Button? NoRadioButton { get; set; }
    
    public RadioButtonPage OpenInBrowser (BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }
    
    public RadioButtonPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }

    public void ClickYesRadioButton()
    {
        YesRadioButton.Click();
    }

    public void ClickNoRadioButton()
    {
        NoRadioButton.Click();
    }

    public void ClickImpressiveRadioButton()
    {
        ImpressiveRadioButton.Click();
    }
    
}