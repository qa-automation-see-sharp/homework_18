using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.Browser;

namespace Tests.Utils.Swd.PageObjects;

public class CheckBoxPage : BasePage.BasePage
{
    public string Url => "https://demoqa.com/checkbox";

    [FindBy(XPath = "//h1[contains(text(),\"Check Box\")]")]
    public WebElement? CheckBoxTitle { get; set; }

    [FindBy(XPath = "//span[@class='rct-title' and text()='Home']")]
    public WebElement? HomeBoxTitle { get; set; }

    [FindBy(XPath = "//button[@aria-label='Expand all' and @title='Expand all']")]
    public Button? ExpandAllButton { get; set; }

    [FindBy(XPath = "//button[@aria-label='Collapse all' and @title='Collapse all']")]
    public Button? CollapseAllButton { get; set; }

    [FindBy(XPath = "//span[@class='rct-title' and text()='Desktop']")]
    public WebElement? DesktopFolder { get; set; }

    [FindBy(XPath = "//span[@class='rct-title' and text()='Documents']")]
    public WebElement? DocumentsFolder { get; set; }

    [FindBy(XPath = "//span[@class='rct-title' and text()='Downloads']")]
    public WebElement? DownloadsFolder { get; set; }

    [FindBy(XPath = "//label[@for='tree-node-home']")]
    public CheckBox? HomeCheckBox { get; set; }

    [FindBy(XPath = "//label[@for='tree-node-notes']")]
    public CheckBox? NotesCheckBox { get; set; }

    [FindBy(XPath = "//label[@for='tree-node-desktop']")]
    public CheckBox? DesktopCheckBox { get; set; }

    [FindBy(XPath = "//label[@for='tree-node-documents']")]
    public CheckBox? DocumentsCheckBox { get; set; }

    [FindBy(XPath = "//label[@for='tree-node-downloads']")]
    public CheckBox? DownloadsCheckBox { get; set; }

    [FindBy(XPath = "//*[@id='result']")]
    public WebElement? Result { get; set; }

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

    public bool VerifyCheckBoxTitle()
    {
        return CheckBoxTitle.Displayed && CheckBoxTitle.Enabled;
    }

    public bool CheckHomeBoxTitle()
    {
        return HomeBoxTitle.Displayed && HomeBoxTitle.Enabled;
    }

    public string ResultText()
    {
        return Result.Text;
    }

    public bool CheckUnrolledFolders()
    {
        try
        {
            var elements = new List<WebElement?>
        {
            DesktopFolder,
            DocumentsFolder,
            DownloadsFolder
        }.Where(e => e != null).ToList();

            return elements.Any() && elements.All(IsElementVisible);

        }
        catch (NullReferenceException e)
        {
            return false;
        }
    }
    private bool IsElementVisible(WebElement? element)
    {
        return element != null && element.Displayed && element.Enabled;
    }

    public CheckBoxPage CheckHomeBox()
    {
        var homeBox = HomeCheckBox;
        homeBox.Click();

        return this;
    }

    public CheckBoxPage CheckNotesBox()
    {
        var notesBox = NotesCheckBox;
        notesBox.Click();

        return this;
    }

    public bool CheckAllBoxesAreChecked()
    {
        var checkBoxes = new List<CheckBox>
        {
            HomeCheckBox,
            DesktopCheckBox,
            DocumentsCheckBox,
            DownloadsCheckBox
        };

        return checkBoxes.All(IsCheckboxChecked);
    }

    private bool IsCheckboxChecked(CheckBox checkbox)
    {
        return checkbox != null && checkbox.Displayed && checkbox.Enabled;
    }
}