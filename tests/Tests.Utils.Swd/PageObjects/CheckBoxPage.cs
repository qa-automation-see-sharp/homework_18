using OpenQA.Selenium;
using Tests.Utils.Swd.BaseElements.Abstractions;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.Browser;

namespace Tests.Utils.Swd.PageObjects;

public class CheckBoxPage : BasePage.BasePage
{
    public string Url => "https://demoqa.com/checkbox";

    [FindBy(XPath = "//button[contains(@class, 'rct-collapse-btn')")]
    private BaseElement? ToggleHome { get; set; }

    [FindBy(XPath = "//span[contains(text(), 'Desktop')]")]
    private BaseElement? FolderDesktop { get; set; }

    [FindBy(XPath = "//span[contains(text(), 'Documents')]")]
    private BaseElement? FolderDocuments { get; set; }

    [FindBy(XPath = "//span[contains(text(), 'Downloads')]")]
    private BaseElement? FolderDownloads { get; set; }

    [FindBy(CssSelector = "label[for='tree-node-home'] .rct-checkbox svg.rct-icon.rct-icon-uncheck")]
    private BaseElement? UncheckedHome { get; set; }

    [FindBy(CssSelector = "label[for='tree-node-desktop'] .rct-checkbox svg.rct-icon.rct-icon-uncheck")]
    private BaseElement? UncheckedDesktop { get; set; }

    [FindBy(CssSelector = "label[for='tree-node-documents'] .rct-checkbox svg.rct-icon.rct-icon-uncheck")]
    private BaseElement? UncheckedDocuments { get; set; }

    [FindBy(CssSelector = "label[for='tree-node-downloads'] .rct-checkbox svg.rct-icon.rct-icon-uncheck")]
    private BaseElement? UncheckedDownloads { get; set; }

    [FindBy(CssSelector = "label[for='tree-node-home'] .rct-checkbox svg.rct-icon.rct-icon-check")]
    private BaseElement? CheckedHome { get; set; }

    [FindBy(CssSelector = "label[for='tree-node-desktop'] .rct-checkbox svg.rct-icon.rct-icon-check")]
    private BaseElement? CheckedDesktop { get; set; }

    [FindBy(CssSelector = "label[for='tree-node-documents'] .rct-checkbox svg.rct-icon.rct-icon-check")]
    private BaseElement? CheckedDocuments { get; set; }

    [FindBy(CssSelector = "label[for='tree-node-downloads'] .rct-checkbox svg.rct-icon.rct-icon-check")]
    private BaseElement? CheckedDownloads { get; set; }

    [FindBy(XPath = "//*[@id='result']")]
    private BaseElement? Output { get; set; }

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

    public void ToggleHomeClick()
    {
        ToggleHome?.Click();
    }
    public bool IsDisplayedFolderList()
    {
        bool IsElementDisplayed(By locator)
        {
            var elements = BrowserFactory.Driver.FindElements(locator);
            return elements.Count > 0 && elements[0].Displayed;
        }

        var folders = new List<bool>()
        {
            IsElementDisplayed(FolderDesktop.Locator),
            IsElementDisplayed(FolderDocuments.Locator),
            IsElementDisplayed(FolderDownloads.Locator)
        };

        return folders.All(x => x);
    }
    public void CheckHome()
    {
        UncheckedHome?.Click();
    }
    public bool IsHomeChecked()
    {
        return CheckedHome!.Displayed;
    }
    public bool IsDesktopChecked()
    {
        return CheckedDesktop!.Displayed;
    }
    public bool IsDocumentsChecked()
    {
        return CheckedDocuments!.Displayed;
    }
    public bool IsDownloadsChecked()
    {
        return CheckedDownloads!.Displayed;
    }
    public bool OutputContainsCheckedElements()
    {
        var outputHome = "home";
        var outputDesktop = FolderDesktop!.Text.ToLower();
        var outputDocuments = FolderDocuments!.Text.ToLower();
        var outputDownloads = FolderDownloads!.Text.ToLower();
        var outputText = "You have selected";
        return Output!.Text.Contains(outputText) &&
                Output.Text.Contains(outputDesktop) &&
                Output.Text.Contains(outputDocuments) &&
                Output.Text.Contains(outputDownloads) &&
                Output.Text.Contains(outputHome);
    }
}