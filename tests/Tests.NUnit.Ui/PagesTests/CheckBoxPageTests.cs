using Tests.Utils.Swd.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.NUnit.Ui.PagesTests;

[TestFixture]
public class CheckBoxPageTests
{
    [OneTimeSetUp]
    public void SetUp()
    {
        _mainPage = new MainPage();
        _mainPage.OpenWith(BrowserNames.Chrome, "--start-maximized");
        _mainPage.NavigateToPage();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _mainPage.Close();
    }

    private MainPage _mainPage;
    private CheckBoxPage _checkBoxPage;

    [Test, Order(1)]
    [Description("This test checks if the user has landed to the page with the correct title")]
    public void GetMainPageTitleTest()
    {
        var title = _mainPage.GetPageTitle();
        
        Assert.That(title, Is.EqualTo("DEMOQA"));
    }

    [Test, Order(2)]
    [Description("This test checks if the user has landed to the page with the correct title")]
    public void OpenCheckboxPageTest()
    {
            var elementsPage = _mainPage.ClickOnCardWithName;
            _checkBoxPage = elementsPage.OpenCheckBoxPage;
            var checkBoxPageTitle = _checkBoxPage.CheckCheckBoxPageTitle();
           
            Assert.That(checkBoxPageTitle, Is.True);
    }

    [Test, Order(3)]
    [Description("This test checks if the expand menu can be opened")]
    public void ExpandMenuTest()
    {
        var isExpandButtonEnabled = _checkBoxPage.CheckExpandButton();
        _checkBoxPage.ExpandMenu();
        var isExpandedMenuDisplayed = _checkBoxPage.CheckExpandedMenuByCommandsCheckBox();
        
        Assert.Multiple(() =>
        {
            Assert.That(isExpandButtonEnabled, Is.True);
            Assert.That(isExpandedMenuDisplayed, Is.True);
        });
    }

    [Test, Order(4)]
    [Description("This test checks if the home checkbox is marked after clicking it")]
    public void MarkHomeCheckBoxTest()
    {
        _checkBoxPage.MarkHomeCheckbox();
        var isHomeCheckBoxMarked = _checkBoxPage.VerifyTheHomeCheckBoxIsMarked();
        
        Assert.That(isHomeCheckBoxMarked, Is.True);
    }

    [Test, Order(5)]
    [Description("This test checks if the other checkboxes are marked and the description is present")]

    public void CheckMarkedElementsAndDescriptionTest()
    {
        var isDocumentsCheckBoxMarked = _checkBoxPage.VerifyTheDocumentsCheckBoxIsMarked();
        var isTheDescriptionOfSelectedItemsIsPresent = _checkBoxPage.CheckTheDescriptionOfSelectedItems();
        var isTheTextOfTheDescriptionDisplayed = _checkBoxPage.CheckTheTextOfTheDescription();
        
        Assert.Multiple(() =>
        {
            Assert.That(isDocumentsCheckBoxMarked, Is.True);
            Assert.That(isTheDescriptionOfSelectedItemsIsPresent, Is.True);
            Assert.That(isTheTextOfTheDescriptionDisplayed, Is.True);
            
        });
    }
    
    [Test, Order(6)]
    [Description("This test checks if the checkboxes are unmarked and the menu is collapsed")]
    public void UnmarkCheckboxAndCloseTheMenuTest()
    {
        _checkBoxPage.UnMarkHomeCheckbox();
        
        var isCollapseButtonEnabled = _checkBoxPage.CheckCollapseButton();
        _checkBoxPage.CollapseMenu();
        var isCollapsedMenuDisplayed = _checkBoxPage.CheckCollapsedMenuByTheHomeFolderIcon();


        Assert.Multiple(() =>
        {
            Assert.That(isCollapseButtonEnabled, Is.True);
            Assert.That(isCollapsedMenuDisplayed, Is.True);
        });
    }
}