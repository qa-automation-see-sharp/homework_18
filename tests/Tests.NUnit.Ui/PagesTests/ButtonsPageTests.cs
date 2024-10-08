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
        _buttonsPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized"/*, "--headless"*/);
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
        _buttonsPage.DoubleClickButton?.DoubleClick();
        _buttonsPage.RightClickButton?.RightClick();
        _buttonsPage.DynamicClickButton?.Click();

        var doubleClickMessage = _buttonsPage.DoubleClickMessage?.Text;

        Assert.Multiple(() =>
        {
            Assert.That(doubleClickMessage, Is.EqualTo("You have done a double click"));
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