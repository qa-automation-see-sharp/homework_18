using OpenQA.Selenium.Interactions;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.Browser;

namespace Tests.Utils.Swd.PageObjects;

public class CheckBoxPage : BasePage.BasePage
{
    public string Url => "https://demoqa.com/checkbox";

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

    [FindBy(XPath = "//label[starts-with(@for, 'tree-node-')]")]
    private WebElements NodeName{get; set;}

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
        return RctCheckBox.Count().Equals(17);
    }

    public void CheckHomeClick(){
        RctCheckBox.FirstOrDefault().Click();
    }

    public string GetResultText(){
        return Result.Text;
    }

    public CheckBoxPage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }
    
    public CheckBoxPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }

    public void CheckItemByName(string name){
        if(RctCheckBox.Count().Equals(1)){
        ExpandAllClick();
        }
        NodeName.FirstOrDefault(e=>e.GetAttribute("for").Contains(name.ToLower())).Click();
    }

    public bool IsDisplayResult(){
        return Result.Displayed;
    }

//TODO:need fix
    // public bool IsNodeHalfCheck(string name){
    //     return NodeName.FirstOrDefault(e=>e.GetAttribute("for").Contains(name.ToLower())).FindElement(HalfCheckBox).Displayed 
    //             && NodeName.FirstOrDefault(e=>e.GetAttribute("for").Contains(name.ToLower())).FindElement(HalfCheckBox).Enabled;
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