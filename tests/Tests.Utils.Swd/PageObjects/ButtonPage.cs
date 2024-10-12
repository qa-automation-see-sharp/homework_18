using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.Browser;

namespace Tests.Utils.Swd.PageObjects;

public class ButtonPage : BasePage.BasePage
{
    public string Url => "https://demoqa.com/buttons";

    [FindBy(Id = "doubleClickBtn")]
    private Button DoubleClickButton { get; set; }

    [FindBy(Id = "rightClickBtn")]
    private Button RightClickButton { get; set; }

    [FindBy(Id = "rSPbL")]
    private Button LeftClickButton { get; set; }

    [FindBy(Id = "doubleClickMessage")]
    private Button DoubleClickMessage { get; set; }

    [FindBy(Id = "rightClickMessage")]
    private Button RightClickMessage { get; set; }

    [FindBy(Id = "dynamicClickMessage")]
    private Button LeftClickMessage { get; set; }

    private string _outputDoubleClick = "You have done a double click";
    private string _outputRightClick = "You have done a right click";
    private string _outputLeftClick = "You have done a dynamic click";

    public ButtonPage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }

    public ButtonPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }

    public bool IsDoubleClickDisplayed()
    {
        return DoubleClickButton.Displayed;
    }

     public bool IsRightClickDisplayed()
    {
        return RightClickButton.Displayed;
    }

     public bool IsLeftClickDisplayed()
    {
        return LeftClickButton.Displayed;
    }

    public bool IsDoubleClickEnabled()
    {
        return DoubleClickButton.Enabled;
    }

     public bool IsRightClickEnabled()
    {
        return RightClickButton.Enabled;
    }

     public bool IsLeftClickEnabled()
    {
        return LeftClickButton.Enabled;
    }

    public void ClickDoubleClickButton()
    {
        DoubleClickButton.DoubleClick();
    }

    public void ClickRightClickButton()
    {
        RightClickButton.RightClick();
    }

    public void ClickLeftClickButton()
    {
        LeftClickButton.Click();
    }

    public bool IsDoubleClickMessageDisplayed()
    {
        return DoubleClickMessage.Displayed;
    }

    public bool IsRightClickMessageDisplayed()
    {
        return RightClickMessage.Displayed;
    }

    public bool IsLeftClickMessageDisplayed()
    {
        return LeftClickMessage.Displayed;
    }

    public bool DoubleClickMessageContainsText()
    {
        return DoubleClickMessage.Text.Contains(_outputDoubleClick);
    }

    public bool RightClickMessageContainsText()
    {
        return RightClickMessage.Text.Contains(_outputRightClick);
    }

    public bool LeftClickMessageContainsText()
    {
        return LeftClickMessage.Text.Contains(_outputLeftClick);
    }
}
