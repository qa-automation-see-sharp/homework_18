using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;

namespace Tests.Utils.Swd.PageObjects;

public class ElementsPage : BasePage.BasePage
{
    

    [FindBy(XPath = "//span[contains(text(),\"Text Box\")]")]
    private Button? TextBox { get; set; }

    [FindBy(XPath = "//span[contains(text(),'Check Box')]")]
    private Button? CheckBox { get; set; }

    public CheckBoxPage OpenCheckBox()
    {
        CheckBox?.Click();
        return new CheckBoxPage();
    }   

    public TextBoxPage OpenTextBox()
    {
        TextBox?.Click();
        return new TextBoxPage();
    }
}