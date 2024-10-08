using Tests.Utils.Swd.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.NUnit.Ui.PagesTests;

[TestFixture]
public class TextBoxPageTests
{
    private TextBoxPage _textBoxPage;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _textBoxPage = new TextBoxPage();
        _textBoxPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized", "--headless");
        _textBoxPage.NavigateToPage();
    }
    
    [Test]
    public void OpenTextBoxPage_TitleIsCorrect()
    {
        var title = _textBoxPage.Title?.Text;

        Assert.That(title, Is.EqualTo("Text Box"));
    }
    
    [Test]
    public void CheckLabelsAreDisplayed()
    {
        var userNameLabel = _textBoxPage.UserNameLabel?.Text;
        var userEmailLabel = _textBoxPage.UserEmailLabel?.Text;
        var currentAddressLabel = _textBoxPage.CurrentAddressLabel?.Text;
        var permanentAddressLabel = _textBoxPage.PermanentAddressLabel?.Text;

        Assert.Multiple(() =>
        {
            Assert.That(userNameLabel, Is.EqualTo("Full Name"));
            Assert.That(userEmailLabel, Is.EqualTo("Email"));
            Assert.That(currentAddressLabel, Is.EqualTo("Current Address"));
            Assert.That(permanentAddressLabel, Is.EqualTo("Permanent Address"));
        });
    }

    [Test]
    public void CompleteTheFormWithData_OutputDisplaysEnteredData()
    {
        _textBoxPage
            .EnterFullName("Oleh Kutafin")
            .EnterEmail("kutafin.o.v@gmail.com")
            .EnterCurrentAddress("7270 W Manchester Ave, Los Angeles, CA 90045")
            .EnterPermanentAddress("13200 Pacific Promenade, Playa Vista, CA 90094")
            .Submit?.Click();

        var textToAssert = _textBoxPage.Output?.Text;

        Assert.Multiple(() =>
        {
            Assert.That(textToAssert, Is.Not.Null);
            Assert.That(textToAssert, Is.Not.Empty);
            Assert.That(textToAssert!.Contains("Oleh Kutafin"));
            Assert.That(textToAssert.Contains("kutafin.o.v@gmail.com"));
            Assert.That(textToAssert.Contains("7270 W Manchester Ave, Los Angeles, CA 90045"));
            Assert.That(textToAssert.Contains("13200 Pacific Promenade, Playa Vista, CA 90094"));
        });
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _textBoxPage.Close();
    }
}