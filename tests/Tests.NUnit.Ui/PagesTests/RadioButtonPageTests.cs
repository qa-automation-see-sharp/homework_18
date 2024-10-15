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
        _radioButtonPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized");
        _radioButtonPage.NavigateToPage();
    }

    [Test]
    public void RadioButtonYes()
    {
        //Arrange - N/A

        //Act        
        _radioButtonPage.ClickYes();
        var isButtonSelected = _radioButtonPage.IsYesSelected();       
        var isButtonEnabled = _radioButtonPage.IsYesEnabled();
        var isOutputDisplayed = _radioButtonPage.IsOutputDisplayed();
        var outputContainsYes = _radioButtonPage.OutputTextContainsYes();

        //Assert
         Assert.Multiple(() => 
        {
            Assert.That(isButtonEnabled, Is.True);
            Assert.That(isButtonSelected, Is.True);
            Assert.That(isOutputDisplayed, Is.True);
            Assert.That(outputContainsYes, Is.True);
        });        
    }

    [Test]
    public void RadioButtonImpressive()
    {
        //Arrange - N/A

        //Act
        _radioButtonPage.ClickImpressive();
        var isButtonSelected = _radioButtonPage.IsImpressiveSelected();
        var isButtonEnabled = _radioButtonPage.IsImpressiveEnabled();        
        var isOutputDisplayed = _radioButtonPage.IsOutputDisplayed();
        var outputContainsYes = _radioButtonPage.OutputTextContainsImpressive();

        //Assert
         Assert.Multiple(() => 
        {
            Assert.That(isButtonEnabled, Is.True);
            Assert.That(isButtonSelected, Is.True);
            Assert.That(isOutputDisplayed, Is.True);
            Assert.That(outputContainsYes, Is.True);
        });        
    }

    [Test]
    public void RadioButtonNo()
    {
        //Arrange - N/A

        //Act
        var isButtonEnabled = _radioButtonPage.IsNoEnabled();   

        //Assert
         Assert.Multiple(() => 
        {
            Assert.That(isButtonEnabled, Is.False);
        });        
    }

    [OneTimeTearDown]
    public void OneTimeTearDownTearDown()
    {
        _radioButtonPage.Close();
    }
}