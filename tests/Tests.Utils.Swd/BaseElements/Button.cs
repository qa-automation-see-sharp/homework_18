using OpenQA.Selenium.Interactions;
using Tests.Utils.Swd.BaseElements.Abstractions;
using Tests.Utils.Swd.Browser;

namespace Tests.Utils.Swd.BaseElements;

public class Button : BaseElement
{
    private readonly Actions _actions = new(BrowserFactory.Driver);

    public void RightClick()
    {
        var elementToClick = FindElement();
        _actions.ContextClick(elementToClick).Build().Perform();
    }

    public void DoubleClick()
    {
        var elementToClick = FindElement();
        _actions.DoubleClick(elementToClick).Build().Perform();
    }
}