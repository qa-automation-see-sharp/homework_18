using Tests.Utils.Swd.PageObjects;
using Tests.Utils.Swd.Browser;

namespace Tests.NUnit.Ui.PagesTests;

[TestFixture]
public class CheckBoxPageTests
{
    private CheckBoxPage _checkBoxPage;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _checkBoxPage = new CheckBoxPage();
        _checkBoxPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized", "--headless");
        _checkBoxPage.NavigateToPage();
    }

    [Test]
    public void GetPageUrl_ShouldReturnCheckBoxUrl()
    {
        //Arrange
        var expectedUrl = _checkBoxPage.Url;

        //Act
        var url = _checkBoxPage.GetPageUrl();  

        //Assert
        Assert.That(url, Is.EqualTo(expectedUrl));        
    }

    [Test]
    public void ExpandCheckBoxList_ShouldDisplayFolders()
    {
        //Arrange - N/A
        
        //Act
        _checkBoxPage.ToggleHomeClick();
        var foldersExpanded = _checkBoxPage.IsDisplayedFolderList();
        _checkBoxPage.ToggleHomeClick();
        var foldersCollapsed = _checkBoxPage.IsDisplayedFolderList();

        //Assert
        Assert.Multiple(() => 
        {
            Assert.That(foldersExpanded, Is.True);
            Assert.That(foldersCollapsed, Is.False);
        });        
    }

    [Test]
    public void CheckBoxesAndOutputText()
    {
        //Arrange - N/A
        _checkBoxPage.ToggleHomeClick();
        
        //Act        
        _checkBoxPage.CheckHome();
        var isCheckedHome = _checkBoxPage.IsHomeChecked();
        var isCheckedDesktop = _checkBoxPage.IsDesktopChecked();
        var isCheckedDocuments = _checkBoxPage.IsDocumentsChecked();
        var isCheckedDownloads = _checkBoxPage.IsDownloadsChecked();
        var outputContainsText = _checkBoxPage.OutputContainsCheckedElements();

        //Assert
        Assert.Multiple(() => 
        {
            Assert.That(isCheckedHome, Is.True);
            Assert.That(isCheckedDesktop, Is.True);
            Assert.That(isCheckedDocuments, Is.True);
            Assert.That(isCheckedDownloads, Is.True);
            Assert.That(outputContainsText, Is.True);
        });        
    }
}