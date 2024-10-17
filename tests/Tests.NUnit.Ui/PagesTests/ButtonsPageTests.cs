using Tests.Utils.Swd.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.NUnit.Ui.PagesTests;

[TestFixture]
public class ButtonsPageTests
{
    private ButtonsPage _buttonsPage;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _buttonsPage = new ButtonsPage();
        _buttonsPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized");
        _buttonsPage.NavigateToPage();
    }
    
    [Test, Order(1)]
    [Description("This test checks if the user has landed to the page with the correct title")]
    public void OpenButtonsPage_TitleIsCorrect()
    {
        var title = _buttonsPage.ButtonsTitle?.Text;

        Assert.That(title, Is.EqualTo("Buttons"));
    }
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _buttonsPage.Close();
    }
}