using OpenQA.Selenium;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using static Tests.Utils.Swd.Browser.BrowserFactory;
using WebElement = OpenQA.Selenium.WebElement;

namespace Tests.Utils.Swd.PageObjects;

public class CheckBoxPage : BasePage.BasePage
{
     public CheckBoxPage(IWebDriver driver)
    {
        Driver = driver;
    }

    [FindBy(XPath = "//h1[contains(text(),\"Check Box\")]")]
    public WebElement CheckBoxPageTitle { get; set; }

    [FindBy(CssSelector = "button[title='Expand all']")]
    public WebElement ExpandButton { get; set; }
    
    [FindBy(XPath = "//div[@id='tree-node']/ol/li/span/label/span[@class='rct-checkbox']")]
    public CheckBox HomeCheckBox { get; set; }
    
    [FindBy(CssSelector = "button[title='Collapse all']")]
    public WebElement CollapseButton { get; set; }
       
    [FindBy(CssSelector = "[for='tree-node-home'] .rct-icon-check")]
    public CheckBox HomeCheckBoxMarked { get; set; }
        
    [FindBy(CssSelector = ".rct-icon.rct-icon-parent-close > path")]
    public WebElement HomeFolderIconInACollapsedMenu { get; set; }
        
    [FindBy(XPath = "//div[@id='tree-node']/ol/li/ol/li[1]/span[@class='rct-text']/label/span[@class='rct-checkbox']")]
    public CheckBox DesktopCheckBox { get; set; }
    
    [FindBy(XPath = "//div[@id='tree-node']/ol/li/ol/li[1]/ol/li[2]/span[@class='rct-text']/label/span[@class='rct-checkbox']")] 
    public CheckBox CommandsCheckBox { get; set; }

    [FindBy(XPath = "//div[@id='tree-node']/ol/li/ol/li[2]/ol/li[1]/ol/li[1]/span[@class='rct-text']")]
    public CheckBox ReactCheckBox { get; set; }
    
    [FindBy(XPath = "//div[@id='tree-node']/ol/li/ol/li[2]/span[@class='rct-text']/label/span[@class='rct-checkbox']")]
    public CheckBox DocumentsCheckBox { get; set; }
   
    [FindBy(CssSelector = "[for='tree-node-documents'] [d='M19 3H5c-1\\.11 0-2 \\.9-2 2v14c0 1\\.1\\.89 2 2 2h14c1\\.11 0 2-\\.9 2-2V5c0-1\\.1-\\.89-2-2-2zm-9 14l-5-5 1\\.41-1\\.41L10 14\\.17l7\\.59-7\\.59L19 8l-9 9z']")]
    public CheckBox DocumentsCheckBoxMarked { get; set; }

    [FindBy(XPath = "//div[@id='tree-node']/ol/li/ol/li[3]/span[@class='rct-text']/label/span[@class='rct-checkbox']")]
    public CheckBox DownloadsCheckBox { get; set; }
        
    [FindBy (XPath = "//div[@id='result']/span[.='You have selected :']")]
    public WebElement DescriptionOfSelectedItems { get; set; }
        

    public bool CheckCheckBoxPageTitle()
    {
        var element = CheckBoxPageTitle;
        return element.Displayed;
    }

    public void ExpandMenu()
    {
        ExpandButton.Click();
        Thread.Sleep(2000);
    }

    public void CollapseMenu()
    {
        CollapseButton.Click();
    }

    public bool CheckExpandButton()
    {
        var element = ExpandButton;
        return element.Displayed && element.Enabled;
    }

    public bool CheckExpandedMenuByCommandsCheckBox()
    {
        var element = CommandsCheckBox;
        return element.Displayed;
    }

    public bool CheckCollapseButton()
    {
        var element = CollapseButton;
        return element.Displayed && element.Enabled;
    }

    public bool CheckCollapsedMenuByTheHomeFolderIcon()
    {
        var element = HomeFolderIconInACollapsedMenu;
        return element.Displayed;
    }

    public void MarkHomeCheckbox()
    {
        HomeCheckBox.Mark();
        //Thread.Sleep(3000); 
    }

    public bool CheckTheDescriptionOfSelectedItems()
    {
        var element = DescriptionOfSelectedItems;
        return element.Displayed;
    }

    public bool CheckTheTextOfTheDescription()
    {
        var element = DescriptionOfSelectedItems;
        return element.Text.Equals("You have selected :");
    }

    public bool VerifyTheHomeCheckBoxIsMarked()
    {
        var element = HomeCheckBoxMarked;
        return element.Displayed;
    }

    public bool VerifyTheDocumentsCheckBoxIsMarked()
    {
        var element = DocumentsCheckBoxMarked;
        return element.Displayed;
    }

    public void UnMarkHomeCheckbox()
    {
        HomeCheckBox.UnMark();
       // Thread.Sleep(5000); 
    }
}