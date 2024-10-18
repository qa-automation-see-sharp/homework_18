using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.Browser;

namespace Tests.Utils.Swd.PageObjects;

public class ButtonsPage: BasePage.BasePage
{
    public string Url => "https://demoqa.com/buttons";
    
    [FindBy(XPath = "//h1[contains(text(),\"Buttons\")]")]
    public WebElement? ButtonsTitle { get; set; }
    
    [FindBy(XPath = "/html//button[@id='doubleClickBtn']")]
    private Button? DoubleClickButton { get; set; }
    
    [FindBy(XPath = "/html//p[@id='doubleClickMessage']")]
    public WebElement? DoubleClickMessage { get; set; }
    
    [FindBy(XPath = "//button[@id='rightClickBtn']")]
    private Button? RightClickButton { get; set; }
    
    [FindBy(XPath = "/html//p[@id='rightClickMessage']")]
    public WebElement? RightClickMessage { get; set; }
    
    [FindBy(XPath = "//button[text()='Click Me']")]
    public WebElement? ClickMeButton { get; set; }
    
    [FindBy(XPath = "/html//p[@id='dynamicClickMessage']")]
    public WebElement? ClickMeMessage { get; set; }

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