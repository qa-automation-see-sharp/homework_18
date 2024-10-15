using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.Browser;

namespace Tests.Utils.Swd.PageObjects;

public class RadioButtonPage : BasePage.BasePage
{
    public string Url => "https://demoqa.com/radio-button";

    [FindBy(XPath = "//label[@class='custom-control-label' and @for='yesRadio']")]
    private WebElement RadioButtonYesLabel { get; set; }

    [FindBy(XPath = "//label[@class='custom-control-label' and @for='impressiveRadio']")]
    private WebElement RadioButtonImpressiveLabel { get; set; }

    [FindBy(Id = "yesRadio")]
    private RadioButton RadioButtonYes { get; set; }

    [FindBy(Id = "impressiveRadio")]
    private RadioButton RadioButtonImpressive { get; set; }
    
    [FindBy(Id = "noRadio")]
    private RadioButton RadioButtonNo { get; set; }
    [FindBy(ClassName = "mt-3")]
    private WebElement? Output { get; set; }
    private string _outputSelection = "You have selected";

    [FindBy(ClassName = "text-success")]
    private WebElement SuccessMessage { get; set; }
    private string _outputYes = "Yes";
    private string _outputImpressive = "Impressive";

    public RadioButtonPage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }

    public RadioButtonPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }

    public void ClickYes()
    {
        RadioButtonYesLabel.Click();
    }

    public void ClickImpressive()
    {
        RadioButtonImpressiveLabel.Click();
    }

    public bool IsYesDisplayed()
    {
        return RadioButtonYes.Displayed;
    }

    public bool IsImpressiveDisplayed()
    {
        return RadioButtonImpressive.Displayed;
    }

    public bool IsNoDisplayed()
    {
        return RadioButtonNo.Displayed;
    }

    public bool IsYesEnabled()
    {
        return RadioButtonYes.Enabled;
    }

    public bool IsImpressiveEnabled()
    {
        return RadioButtonImpressive.Enabled;
    }

    public bool IsNoEnabled()
    {
        return RadioButtonNo.Enabled;
    }

    public bool IsYesSelected()
    {
        return RadioButtonYes.Selected;
    }

    public bool IsImpressiveSelected()
    {
        return RadioButtonImpressive.Selected;
    }

    public bool IsOutputDisplayed()
    {
        return Output.Displayed;
    }

    public bool OutputTextContainsYes()
    {
        return Output.Text.Contains(_outputSelection) &&
               SuccessMessage.Text.Contains(_outputYes);
    }

    public bool OutputTextContainsImpressive()
    {
        return Output.Text.Contains(_outputSelection) &&
               SuccessMessage.Text.Contains(_outputImpressive);
    }
}