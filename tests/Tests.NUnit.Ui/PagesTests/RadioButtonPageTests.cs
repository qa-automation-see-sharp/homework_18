using Tests.Utils.Swd.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.NUnit.Ui.PagesTests;

[TestFixture]
public class RadioButtonPageTests
{
    private RadioButtonPage _radioButtonPage;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _radioButtonPage = new RadioButtonPage();
        _radioButtonPage.OpenInBrowser(BrowserNames.Firefox, "--start-maximized");
        _radioButtonPage.NavigateToPage();
    }

    [Test]
    public void OpenRadioBoxPage_TitleIsCorrect()
    {
        var title = _radioButtonPage.Title?.Text;

        Assert.That(title, Is.EqualTo("Radio Button"));
    }

    [Test]
    public void CheckYesRadioOutput()
    {
        _radioButtonPage.YesRadio?.Click();

        var output = _radioButtonPage.Output?.Text;

        Assert.That(output, Is.EqualTo("You have selected Yes"));
    }

    [Test]
    public void CheckImpressiveRadioButtons()
    {
        _radioButtonPage.Impressive?.Click();
        var output = _radioButtonPage.Output?.Text;

        Assert.That(output, Does.Contain("Impressive"));
    }

    [Test]
    public void CheckTextQuetion()
    {
        var text = _radioButtonPage.QuetionText.Text;
        Assert.That(text, Is.EqualTo("Do you like the site?"));
    }

    
    [Test]
    public void CheckNoButton()
    {
        // Check if NoButton is null
        if (_radioButtonPage.NoButton == null)
        {
            Assert.Fail("NoButton element is null. Check the locator or page initialization.");
        }

        // Try to get the class attribute and compare it
        var noButtonClass = _radioButtonPage.NoButton.GetAttribute("class");

        if (noButtonClass == null)
        {
            Assert.Fail("NoButton class attribute is null.");
        }

        // Check if the class attribute contains the expected value
        var isDisabled = noButtonClass.Equals("custom-control-input disabled");

        Assert.False(isDisabled, "NoButton is not disabled as expected.");
    }


    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _radioButtonPage.Close();
    }
}