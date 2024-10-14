using Tests.Utils.Swd.Browser;
using Tests.Utils.Swd.Helpers;
using static Tests.Utils.Swd.Helpers.WaitHelper;
using static Tests.Utils.Swd.Browser.BrowserFactory;

namespace Tests.Utils.Swd.BasePage;

public abstract class BasePage
{
    protected BasePage()
    {
        InitializationHelper.InitializeElements(this);
    }

    protected void OpenWith(BrowserNames name, params string[] args)
    {
        BrowserFactory.OpenWith(name, args);
    }

    public string GetPageTitle()
    {
        return Driver!.Title;
    }

    public string GetPageUrl()
    {
        return Driver!.Url;
    }

    protected void NavigateTo(string url)
    {
        Wait(() => Driver?.Navigate().GoToUrl(url));
    }

    public void RefreshPage()
    {
        Wait(() => Driver?.Navigate().Refresh());
    }

    public void GoBack()
    {
        Wait(() => Driver?.Navigate().Back());
    }

    public void GoForward()
    {
        Wait(() => Driver?.Navigate().Forward());
    }

    public void Close()
    {
        CloseBrowser();
    }
}