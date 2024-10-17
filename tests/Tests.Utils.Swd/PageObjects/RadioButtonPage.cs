using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;

namespace Tests.Utils.Swd.PageObjects;

public class RadioButtonPage: BasePage.BasePage
{
    [FindBy(CssSelector = "[for='yesRadio']")]
    private Button? YesRadioButton { get; set; }
    
    [FindBy(CssSelector = "[for='impressiveRadio']")]
    private Button? ImpressiveRadioButton { get; set; }
    
    [FindBy(CssSelector = "[for='noRadio']")]
    private Button? NoRadioButton { get; set; }
    
    
}