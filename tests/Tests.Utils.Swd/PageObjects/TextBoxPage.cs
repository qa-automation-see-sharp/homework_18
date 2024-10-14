using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.Browser;

namespace Tests.Utils.Swd.PageObjects;

public class TextBoxPage : BasePage.BasePage
{
    public string Url => "https://demoqa.com/text-box";

    [FindBy(XPath = "//h1[contains(text(),\"Text Box\")]")]
    public WebElement? Title { get; set; }

    [FindBy(Id = "userName-label")]
    public WebElement? UserNameLabel { get; set; }

    [FindBy(Id = "userName")]
    public Input? UserName { get; set; }

    [FindBy(Id = "userEmail-label")]
    public WebElement? UserEmailLabel { get; set; }

    [FindBy(Id = "userEmail")]
    public Input? UserEmail { get; set; }

    [FindBy(Id = "currentAddress-label")]
    public WebElement? CurrentAddressLabel { get; set; }

    [FindBy(Id = "currentAddress")]
    public Input? CurrentAddress { get; set; }

    [FindBy(Id = "permanentAddress-label")]
    public WebElement? PermanentAddressLabel { get; set; }

    [FindBy(Id = "permanentAddress")]
    public Input? PermanentAddress { get; set; }

    [FindBy(XPath = "//button[@id='submit']")]
    public Button? Submit { get; set; }

    [FindBy(Id = "output")]
    public WebElement? Output { get; set; }

    public TextBoxPage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }
    
    public TextBoxPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }

    public TextBoxPage EnterFullName(string fullName)
    {
        UserName?.SendKeys(fullName);
        return this;
    }

    public TextBoxPage EnterEmail(string email)
    {
        UserEmail?.SendKeys(email);
        return this;
    }

    public TextBoxPage EnterCurrentAddress(string currentAddress)
    {
        CurrentAddress?.SendKeys(currentAddress);
        return this;
    }

    public TextBoxPage EnterPermanentAddress(string permanentAddress)
    {
        PermanentAddress?.SendKeys(permanentAddress);
        return this;
    }
}