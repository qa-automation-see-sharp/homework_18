using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.Browser;

namespace Tests.Utils.Swd.PageObjects;

public class MainPage : BasePage.BasePage
{
    private string Url => "https://demoqa.com/";
    public string Title => "DEMOQA";

    [FindBy(XPath = "//div[@class='card-body']")]
    public WebElements Cards { get; set; }
 

    public MainPage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }

    public MainPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }

    public ElementsPage ClickOnCardWithName(string cardName)
    {
        Cards.FirstOrDefault(e => e.Text.Contains(cardName))?.Click();
        return new ElementsPage();
    }
    
}