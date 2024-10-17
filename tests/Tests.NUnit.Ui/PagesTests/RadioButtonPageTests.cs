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
        _radioButtonPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized");
        _radioButtonPage.NavigateToPage();
    }
    
    [Test]
    public void OpenRadioButtonPage_TitleIsCorrect()
    {
        var title = _radioButtonPage.Title?.Text;

        Assert.That(title, Is.EqualTo("Radio Button"));
    }
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _radioButtonPage.Close();
    }
}