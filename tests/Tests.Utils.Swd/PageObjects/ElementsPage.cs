using OpenQA.Selenium;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.Browser;
using static Tests.Utils.Swd.Browser.BrowserFactory;
using WebElement = Tests.Utils.Swd.BaseElements.WebElement;

namespace Tests.Utils.Swd.PageObjects;

public class ElementsPage : BasePage.BasePage
{

    [FindBy(XPath = "//span[contains(text(),\"Text Box\")]")]
    private Button? TextBox { get; set; }
    
    [FindBy(XPath = "//div[@id='app']/div[@class='body-height']/div[@class='container playgound-body']/div[@class='row']//div[@class='accordion']/div[1]/div/ul[@class='menu-list']/li[2]/span[@class='text']")]
    private WebElements CheckBox { get; set; }
    

    public TextBoxPage OpenTextBox()
    {
        TextBox?.Click();
        return new TextBoxPage();
    }
    
    public CheckBoxPage OpenCheckBoxPage()
    {
        CheckBox.Click();
        return new CheckBoxPage(BrowserFactory.Driver);
    }
    
}