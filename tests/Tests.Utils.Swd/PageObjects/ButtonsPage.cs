using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.Browser;

namespace Tests.Utils.Swd.PageObjects;

public class ButtonsPage: BasePage.BasePage
{
    public string Url => "https://demoqa.com/buttons";
    
    [FindBy(XPath = "//h1[contains(text(),\"Buttons\")]")]
    private WebElement? ButtonsTitle { get; set; }
    
    [FindBy(XPath = "/html//button[@id='doubleClickBtn']")]
    private Button? DoubleClickButton { get; set; }
    
    [FindBy(XPath = "/html//p[@id='doubleClickMessage']")]
    private WebElement? DoubleClickMessage { get; set; }
    
    [FindBy(XPath = "/html//button[@id='rightClickBtn']")]
    private Button? RightClickButton { get; set; }
    
    [FindBy(XPath = "/html//p[@id='rightClickMessage']")]
    private WebElement? RightClickMessage { get; set; }
    
    [FindBy(ClassName = "btn btn-primary")]
    private Button? ClickMeButton { get; set; }
    
    [FindBy(XPath = "/html//p[@id='dynamicClickMessage']")]
    private WebElement? ClickMeMessage { get; set; }

    public ButtonsPage OpenInBrowser (BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }
    
    public ButtonsPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }
    
    public void DoubleClick()
    {
        DoubleClickButton.DoubleClick();
    }
    
    public void RightClick()
    {
        RightClickButton.RightClick();
    }
    
    public void ClickMe()
    {
        ClickMeButton.Click();
    }
}