using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.Browser;

namespace Tests.Utils.Swd.PageObjects;

public class ButtonsPage : BasePage.BasePage
{
    public string Url => "https://demoqa.com/buttons";

    [FindBy(XPath = "//h1[contains(text(),\"Buttons\")]")]
    public WebElement? Title { get; set; }

    [FindBy(Id = "doubleClickBtn")]
    public Button? DoubleClickButton { get; set; }
    [FindBy(Id = "rightClickBtn")]
    public Button? RightClickButton { get; set; }
    [FindBy(XPath ="//button[text() = 'Click Me']")]
    public Button? DynamicClickButton { get; set; }
    [FindBy(XPath = "//p[@id = 'doubleClickMessage')]")]
    public WebElement? DoubleClickMessage { get; set; }
    [FindBy(Id = "rightClickMessage")]
    public WebElement? RightClickMessage { get; set; }
    [FindBy(Id = "dynamicClickMessage")]
    public WebElement? DynamicClickMessage { get; set; }

    public ButtonsPage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }
    
    public ButtonsPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }
}