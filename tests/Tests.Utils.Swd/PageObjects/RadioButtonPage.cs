using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.Browser;

namespace Tests.Utils.Swd.PageObjects;

public class RadioButtonPage : BasePage.BasePage
{
    public string Url => "https://demoqa.com/radio-button";

    [FindBy(XPath = "//h1[contains(text(),\"Radio Button\")]")]
    public WebElement? Title { get; set; }

    [FindBy(Id = "yesRadio")]
    public Button? YesRadio { get; set; }

    [FindBy(XPath = "//p[@class='mt-3']")]
    public WebElement? Output { get; set; }

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