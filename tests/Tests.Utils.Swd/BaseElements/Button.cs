using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Tests.Utils.Swd.BaseElements.Abstractions;
using Tests.Utils.Swd.Browser;

namespace Tests.Utils.Swd.BaseElements;

public class Button : BaseElement
{
   

    public void RightClick()
    {
        var action = new Actions(BrowserFactory.Driver);
        var elementToClick = FindElement();
        action.ContextClick(elementToClick).Build().Perform();
    }

    public void DoubleClick()
    {
        var action = new Actions(BrowserFactory.Driver);
        var elementToClick = FindElement();
        action.DoubleClick(elementToClick).Build().Perform();
    }
    public bool IsDisplayed()
    {
        try
        {
            // Find the element and return whether it's displayed
            return FindElement().Displayed;
        }
        catch (NoSuchElementException)
        {
            // If the element is not found, return false
            return false;
        }
    }
}