using Tests.Utils.Swd.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.xUnit.Ui.PagesTests;
public class TextBoxPageTests : IDisposable
{
    private TextBoxPage _textBoxPage;

    public TextBoxPageTests()
    {
        _textBoxPage = new TextBoxPage();
        _textBoxPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized", "--headless");
        _textBoxPage.NavigateToPage();
    }

    [Fact]
    public void OpenTextBoxPage_TitleIsCorrect()
    {
        var title = _textBoxPage.Title?.Text;
        Assert.Equal("Text Box", title);
    }

    [Fact]
    public void CheckLabelsAreDisplayed()
    {
        var userNameLabel = _textBoxPage.UserNameLabel?.Text;
        var userEmailLabel = _textBoxPage.UserEmailLabel?.Text;
        var currentAddressLabel = _textBoxPage.CurrentAddressLabel?.Text;
        var permanentAddressLabel = _textBoxPage.PermanentAddressLabel?.Text;

        Assert.True(userNameLabel == "Full Name");
        Assert.True(userEmailLabel == "Email");
        Assert.True(currentAddressLabel == "Current Address");
        Assert.True(permanentAddressLabel == "Permanent Address");
    }

    [Fact]
    public void CompleteTheFormWithData_OutputDisplaysEnteredData()
    {
        _textBoxPage
            .EnterFullName("Oleh Kutafin")
            .EnterEmail("kutafin.o.v@gmail.com")
            .EnterCurrentAddress("7270 W Manchester Ave, Los Angeles, CA 90045")
            .EnterPermanentAddress("13200 Pacific Promenade, Playa Vista, CA 90094")
            .Submit?.Click();

        var textToAssert = _textBoxPage.Output?.Text;

        Assert.NotNull(textToAssert);
        Assert.NotEmpty(textToAssert);
        Assert.Contains("Oleh Kutafin", textToAssert);
        Assert.Contains("kutafin.o.v@gmail.com", textToAssert);
        Assert.Contains("7270 W Manchester Ave, Los Angeles, CA 90045", textToAssert);
        Assert.Contains("13200 Pacific Promenade, Playa Vista, CA 90094", textToAssert);
    }

    public void Dispose()
    {
        _textBoxPage.Close();
    }
}
