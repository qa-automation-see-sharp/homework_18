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
    [FindBy(Id = "doubleClickMessage")]
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
    public bool WaitForElementText(WebElement element, string expectedText, int maxWaitTimeInSeconds = 10)
    {
        DateTime endTime = DateTime.Now.AddSeconds(maxWaitTimeInSeconds);
        while (DateTime.Now < endTime)
        {
            if (element != null && element.Text == expectedText)
            {
                return true;
            }
            Thread.Sleep(500);
        }
        return false;
    }
}