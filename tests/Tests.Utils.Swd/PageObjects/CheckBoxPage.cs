using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Interactions;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.Browser;

namespace Tests.Utils.Swd.PageObjects;

public class CheckBoxPage : BasePage.BasePage
{
    [FindBy(CssSelector = "h1.text-center")]
    public WebElement? CheckBoxTitle { get; set; }

    [FindBy(CssSelector = "button.rct-option.rct-option-expand-all")]
    public Button? ExpandAllButton { get; set; }
    
    [FindBy(CssSelector = "button.rct-option.rct-option-collapse-all")]
    private Button? CollapseAllButton { get; set; }

    [FindBy(Id = "result")]
    public WebElement? Result { get; set; }

    [FindBy(XPath = "//*[contains(@class,'-uncheck')]")]
    public WebElement UnCheck { get; set; }

    [FindBy(XPath = "//*[contains(@class,'icon-check')]")]
    public WebElement CheckBox { get; set; }

    [FindBy(XPath = "//*[contains(@class,'half-check')]")]
    public WebElement HalfCheckBox { get; set; }

    [FindBy(XPath = "//*[@class='rct-icon rct-icon-uncheck' or @class='rct-icon rct-icon-check' or @class='rct-icon rct-icon-half-check']")]
    public  WebElements RctCheckBox { get; set; }

    //private WebElement NodeName(string name) => XPath($"//label[starts-with(@for, 'tree-node-{name}')]");

    public string ResultText()
    {
        return Result.Text;
    }

    public CheckBoxPage CollapseAllClick()
    {
        CollapseAllButton.Click();
        return this;
    }

    public CheckBoxPage ExpandAllClick()
    {
        ExpandAllButton.Click();
        return this;
    }

    public string GetTitleCheckBox(){
        return CheckBoxTitle.Text;
    }

    public bool IsExpandAll (){
        return RctCheckBox.Equals(17);
    }

    public void CheckHomeClick(){
        RctCheckBox.Click();
    }

    public string GetResultText(){
        return Result.Text;
    }

    // public void CheckItemByName(string name){
    //     if(RctCheckBox.Equals(1)){
    //     ExpandAllClick();
    //     }
    //     var ele = NodeName(name.ToLower());
    //     new Actions(Driver)
    //     .ScrollByAmount(0, ele.Location.Y/5)
    //     .Perform();
    //     ele.Click();
    // }

    public bool IsDisplayResult(){
        return Result.Displayed;
    }
//TODO: need fix
    // public bool IsNodeHalfCheck(string nameNode){
    //     return Driver.FindElement(NodeName(nameNode.ToLower())).FindElement(HalfCheckBox).Displayed 
    //             && Driver.FindElement(NodeName(nameNode.ToLower())).FindElement(HalfCheckBox).Enabled;
    // }

    // public bool IsNodeChecked(string nameNode){
    //     return Driver.FindElement(NodeName(nameNode.ToLower())).FindElement(CheckBox).Displayed 
    //             && Driver.FindElement(NodeName(nameNode.ToLower())).FindElement(CheckBox).Enabled;
    // }

    // public bool IsNodeUncheck(string nameNode){
    //     return Driver.FindElement(NodeName(nameNode.ToLower())).FindElement(UnCheck).Displayed 
    //             && Driver.FindElement(NodeName(nameNode.ToLower())).FindElement(UnCheck).Enabled;
    // }
}