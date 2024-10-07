using Tests.Utils.Swd.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.NUnit.Ui.PagesTests;

[TestFixture]
public class RadioButtonPageTests
{
    private RadioButtonPage _radioButtonPage;

    [OneTimeSetUp]
    public void OneTimeSetUpSetUp()
    {
        _radioButtonPage = new RadioButtonPage();
        _radioButtonPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized", "--headless");
        _radioButtonPage.NavigateToPage();
    }

    [Test]
    public void RadioButtonYes()
    {
        //Arrange - N/A

        //Act
        var isButtonDisplayed = _radioButtonPage.IsYesDisplayed();
        var isButtonEnabled = _radioButtonPage.IsYesEnabled();
        _radioButtonPage.ClickYes();
        var isButtonSelected = _radioButtonPage.IsYesSelected();

        var isOutputDisplayed = _radioButtonPage.IsOutputDisplayed();
        var outputContainsYes = _radioButtonPage.OutputTextContainsYes();

        //Assert
         Assert.Multiple(() => 
        {
            Assert.That(isButtonDisplayed, Is.True);
            Assert.That(isButtonEnabled, Is.True);
            Assert.That(isButtonSelected, Is.True);
            Assert.That(isOutputDisplayed, Is.True);
            Assert.That(outputContainsYes, Is.True);
        });        
    }
}