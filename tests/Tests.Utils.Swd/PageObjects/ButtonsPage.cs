using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;

namespace Tests.Utils.Swd.PageObjects;

public class ButtonsPage: BasePage.BasePage
{
    [FindBy(XPath = "/html//button[@id='doubleClickBtn']")]
    private Button DoubleClickButton { get; set; }
    
    [FindBy(XPath = "/html//button[@id='rightClickBtn']")]
    private Button RightClickButton { get; set; }
    
    [FindBy(ClassName = "btn btn-primary")]
    private Button ClickMeButton { get; set; }
}