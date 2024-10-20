using System;
using Tests.Utils.Swd.Browser;
using Tests.Utils.Swd.PageObjects;
using Xunit;

namespace Tests.xUnit.Ui.PagesTests
{
    public class RadioButtonPageTests : IDisposable
    {
        private readonly RadioButtonPage _radioButtonPage;

        // Constructor to open browser and navigate to the page once
        public RadioButtonPageTests()
        {
            _radioButtonPage = new RadioButtonPage();
            _radioButtonPage.OpenInBrowser(BrowserNames.Firefox, "--start-maximized");
            _radioButtonPage.NavigateToPage();
        }

        // Test case to validate that the page title is correct
        [Fact]
        public void OpenRadioBoxPage_TitleIsCorrect()
        {
            var title = _radioButtonPage.Title?.Text;
            Assert.Equal("Radio Button", title);
        }

        // Test case to validate that selecting the "Yes" radio button shows the correct output
        [Fact]
        public void CheckYesRadioOutput()
        {
            _radioButtonPage.YesRadio?.Click();
            var output = _radioButtonPage.Output?.Text;
            Assert.Equal("You have selected Yes", output);
        }

        // Test case to validate that selecting the "Impressive" radio button shows the correct output
        [Fact]
        public void CheckImpressiveRadioButtons()
        {
            _radioButtonPage.Impressive?.Click();
            var output = _radioButtonPage.Output?.Text;
            Assert.Contains("Impressive", output);
        }

        // Test case to validate the question text is correct
        [Fact]
        public void CheckTextQuestion()
        {
            var text = _radioButtonPage.QuetionText.Text;
            Assert.Equal("Do you like the site?", text);
        }

        // Test case to validate the "No" button is disabled as expected
        [Fact]
        public void CheckNoButton()
        {
            // Check if NoButton is null
            Assert.NotNull(_radioButtonPage.NoButton);

            // Get the class attribute and compare it
            var noButtonClass = _radioButtonPage.NoButton.GetAttribute("class");
            Assert.NotNull(noButtonClass);

            // Check if the class attribute contains the expected value
            var isDisabled = noButtonClass.Equals("custom-control-input disabled");
            Assert.False(isDisabled, "NoButton is not disabled as expected.");
        }

        // Dispose method to close the browser once all tests are done
        public void Dispose()
        {
            _radioButtonPage.Close();
        }
    }
}
