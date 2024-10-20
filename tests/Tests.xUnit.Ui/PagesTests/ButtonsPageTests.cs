using Tests.Utils.Swd.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.xUnit.Ui.PagesTests
{
    public class ButtonPageTests : IDisposable
    {
        private readonly ButtonPage _buttonsPage;

        // Constructor to open browser and navigate to the page before each test
        public ButtonPageTests()
        {
            _buttonsPage = new ButtonPage();
            _buttonsPage.OpenInBrowser(BrowserNames.Firefox, "--start-maximized");
            _buttonsPage.NavigateToPage();
        }

        // Test case to validate that the page title is correct
        [Fact]
        public void OpenButtonsPage_TitleIsCorrect()
        {
            var title = _buttonsPage.Title?.Text;
            Assert.Equal("Buttons", title);
        }

        // Test case to check if all button click messages are correctly displayed
        [Fact]
        public void CheckButtonMessages_AfterClickActions()
        {
            // Perform actions on buttons
            _buttonsPage.DoubleClickMeButton?.DoubleClick();
            _buttonsPage.RightClickMeButton?.RightClick();
            _buttonsPage.ClickMeButton?.Click();

            // Validate that messages are displayed correctly
            Assert.Collection(new[]
            {
                _buttonsPage.DoubleClickMessage?.Text,
                _buttonsPage.RightClickMessage?.Text,
                _buttonsPage.DynamicClickMessage?.Text
            },
            message => Assert.Equal("You have done a double click", message),
            message => Assert.Equal("You have done a right click", message),
            message => Assert.Equal("You have done a dynamic click", message));
        }

        // New Test: Validate that all buttons are displayed correctly
        [Fact]
        public void CheckAllButtonsAreVisible()
        {
            Assert.Collection(new[]
            {
                _buttonsPage.DoubleClickMeButton?.IsDisplayed(),
                _buttonsPage.RightClickMeButton?.IsDisplayed(),
                _buttonsPage.ClickMeButton?.IsDisplayed()
            },
            isVisible => Assert.True(isVisible, "Double Click Me button should be visible."),
            isVisible => Assert.True(isVisible, "Right Click Me button should be visible."),
            isVisible => Assert.True(isVisible, "Click Me button should be visible."));
        }

        // New Test: Validate the DoubleClick action is functioning as expected
        [Fact]
        public void DoubleClickMeButton_ShowsCorrectMessage()
        {
            _buttonsPage.DoubleClickMeButton?.DoubleClick();
            var message = _buttonsPage.DoubleClickMessage?.Text;
            Assert.Equal("You have done a double click", message);
        }

        // New Test: Validate the RightClick action is functioning as expected
        [Fact]
        public void RightClickMeButton_ShowsCorrectMessage()
        {
            _buttonsPage.RightClickMeButton?.RightClick();
            var message = _buttonsPage.RightClickMessage?.Text;
            Assert.Equal("You have done a right click", message);
        }

        // New Test: Validate the dynamic Click Me button works correctly
        [Fact]
        public void DynamicClickMeButton_ShowsCorrectMessage()
        {
            _buttonsPage.ClickMeButton?.Click();
            var message = _buttonsPage.DynamicClickMessage?.Text;
            Assert.Equal("You have done a dynamic click", message);
        }

        // Dispose method to close the browser after each test
        public void Dispose()
        {
            _buttonsPage.Close();
        }
    }
}