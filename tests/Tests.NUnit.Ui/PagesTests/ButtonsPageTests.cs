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
        _buttonsPage.OpenInBrowser(BrowserNames.Firefox, "--start-maximized", "--headless");
        _buttonsPage.NavigateToPage();
    }

    [Test]
    public void OpenButtonsPage_TitleIsCorrect()
    {
        var title = _buttonsPage.Title?.Text;

        Assert.That(title, Is.EqualTo("Buttons"));
    }

    [Test]
    public void CheckLabelsAreDisplayed()
    {
        _buttonsPage.DoubleClickMeButton?.DoubleClick();
        _buttonsPage.RightClickMeButton?.RightClick();
        _buttonsPage.ClickMeButton?.Click();

        Assert.Multiple(() =>
        {
            Assert.That(_buttonsPage.DoubleClickMessage?.Text, Is.EqualTo("You have done a double click"));
            Assert.That(_buttonsPage.RightClickMessage?.Text, Is.EqualTo("You have done a right click"));
            Assert.That(_buttonsPage.DynamicClickMessage?.Text, Is.EqualTo("You have done a dynamic click"));
        });
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _buttonsPage.Close();
    }
}