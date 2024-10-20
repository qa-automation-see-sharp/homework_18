using Tests.Utils.Swd.Browser;
using Tests.Utils.Swd.PageObjects;
using NUnit.Framework;

namespace Tests.NUnit.Ui.PagesTests
{
    [TestFixture]
    public class ButtonPageTests
    {
        private ButtonPage _buttonsPage;

        // Setup method to open browser and navigate to the page before each test
        [SetUp]
        public void SetUp()
        {
            _buttonsPage = new ButtonPage();
            _buttonsPage.OpenInBrowser(BrowserNames.Firefox, "--start-maximized");
            _buttonsPage.NavigateToPage();
        }

        // Test case to validate that the page title is correct
        [Test]
        public void OpenButtonsPage_TitleIsCorrect()
        {
            var title = _buttonsPage.Title?.Text;
            Assert.That(title, Is.EqualTo("Buttons"), "The page title should be 'Buttons'.");
        }

        // Test case to check if all button click messages are correctly displayed
        [Test]
        public void CheckButtonMessages_AfterClickActions()
        {
            // Perform actions on buttons
            _buttonsPage.DoubleClickMeButton?.DoubleClick();
            _buttonsPage.RightClickMeButton?.RightClick();
            _buttonsPage.ClickMeButton?.Click();

            // Validate that messages are displayed correctly
            Assert.Multiple(() =>
            {
                Assert.That(_buttonsPage.DoubleClickMessage?.Text, Is.EqualTo("You have done a double click"), "Double click message mismatch.");
                Assert.That(_buttonsPage.RightClickMessage?.Text, Is.EqualTo("You have done a right click"), "Right click message mismatch.");
                Assert.That(_buttonsPage.DynamicClickMessage?.Text, Is.EqualTo("You have done a dynamic click"), "Dynamic click message mismatch.");
            });
        }

        // New Test: Validate that all buttons are displayed correctly
        [Test]
        public void CheckAllButtonsAreVisible()
        {
            Assert.Multiple(() =>
            {
                // Call IsDisplayed() with parentheses, since it is a method
                Assert.That(_buttonsPage.DoubleClickMeButton?.IsDisplayed(), Is.True, "Double Click Me button should be visible.");
                Assert.That(_buttonsPage.RightClickMeButton?.IsDisplayed(), Is.True, "Right Click Me button should be visible.");
                Assert.That(_buttonsPage.ClickMeButton?.IsDisplayed(), Is.True, "Click Me button should be visible.");
            });
        }

        // New Test: Validate the DoubleClick action is functioning as expected
        [Test]
        public void DoubleClickMeButton_ShowsCorrectMessage()
        {
            _buttonsPage.DoubleClickMeButton?.DoubleClick();
            var message = _buttonsPage.DoubleClickMessage?.Text;
            Assert.That(message, Is.EqualTo("You have done a double click"), "Double Click action did not trigger the correct message.");
        }

        // New Test: Validate the RightClick action is functioning as expected
        [Test]
        public void RightClickMeButton_ShowsCorrectMessage()
        {
            _buttonsPage.RightClickMeButton?.RightClick();
            var message = _buttonsPage.RightClickMessage?.Text;
            Assert.That(message, Is.EqualTo("You have done a right click"), "Right Click action did not trigger the correct message.");
        }

        // New Test: Validate the dynamic Click Me button works correctly
        [Test]
        public void DynamicClickMeButton_ShowsCorrectMessage()
        {
            _buttonsPage.ClickMeButton?.Click();
            var message = _buttonsPage.DynamicClickMessage?.Text;
            Assert.That(message, Is.EqualTo("You have done a dynamic click"), "Dynamic Click did not trigger the correct message.");
        }

        // Cleanup method to close the browser after each test
        [TearDown]
        public void TearDown()
        {
            _buttonsPage.Close();
        }
    }
}
