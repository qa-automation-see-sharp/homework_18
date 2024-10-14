using static Tests.Utils.Swd.Browser.BrowserFactory;
using Tests.Utils.Swd.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.NUnit.Ui.PagesTests;

[TestFixture]
public class ButtonsPageTests
{
    private ButtonPage _buttonPage;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _buttonPage = new ButtonPage();
        _buttonPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized", "--headless");
        _buttonPage.NavigateToPage();
    }

    [Test]
    public void DoubleClickButtonTest()
    {
        //Arrange - N/A

        //Act
        var isButtonDisplayed = _buttonPage.IsDoubleClickDisplayed();
        var isButtonEnabled = _buttonPage.IsDoubleClickEnabled();
        _buttonPage.ClickDoubleClickButton();
        var isMessageDisplayed = _buttonPage.IsDoubleClickMessageDisplayed();
        var messageContainsText = _buttonPage.DoubleClickMessageContainsText();

        //Assert
         Assert.Multiple(() => 
        {
            Assert.That(isButtonDisplayed, Is.True);
            Assert.That(isButtonEnabled, Is.True);
            Assert.That(isMessageDisplayed, Is.True);
            Assert.That(messageContainsText, Is.True);            
        });        
    }

    [Test]
    public void RightClickButtonTest()
    {
        //Arrange - N/A

        //Act
        var isButtonDisplayed = _buttonPage.IsRightClickDisplayed();
        var isButtonEnabled = _buttonPage.IsRightClickEnabled();
        _buttonPage.ClickRightClickButton();
        var isMessageDisplayed = _buttonPage.IsRightClickMessageDisplayed();
        var messageContainsText = _buttonPage.RightClickMessageContainsText();

        //Assert
         Assert.Multiple(() => 
        {
            Assert.That(isButtonDisplayed, Is.True);
            Assert.That(isButtonEnabled, Is.True);
            Assert.That(isMessageDisplayed, Is.True);
            Assert.That(messageContainsText, Is.True);            
        });        
    }

    [Test]
    public void LeftClickButtonTest()
    {
        //Arrange - N/A

        //Act
        var isButtonDisplayed = _buttonPage.IsLeftClickDisplayed();
        var isButtonEnabled = _buttonPage.IsLeftClickEnabled();
        _buttonPage.ClickLeftClickButton();
        var isMessageDisplayed = _buttonPage.IsLeftClickMessageDisplayed();
        var messageContainsText = _buttonPage.LeftClickMessageContainsText();

        //Assert
         Assert.Multiple(() => 
        {
            Assert.That(isButtonDisplayed, Is.True);
            Assert.That(isButtonEnabled, Is.True);
            Assert.That(isMessageDisplayed, Is.True);
            Assert.That(messageContainsText, Is.True);            
        });        
    }
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        CloseBrowser();
    }
}