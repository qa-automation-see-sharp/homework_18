using Tests.Utils.Swd.PageObjects;
using static Tests.Utils.Swd.Browser.BrowserNames;

namespace Tests.NUnit.Ui.PagesTests;

[TestFixture]
public class CheckBoxPageTests
{
    private MainPage _mainPage;

    [SetUp]
    public void Setup()
    {
        _mainPage = new MainPage();
        _mainPage.OpenInBrowser(Firefox, "--start-maximized");
    }

    [Test]
    public void ExpandAndCollapsAll()
    {
        _mainPage.NavigateToPage();
        var title = _mainPage.GetPageTitle();
        var elementsPage = _mainPage.ClickOnCardWithName("Elements");

        var checkBoxPage = elementsPage.OpenCheckBox();
        checkBoxPage.ExpandAllClick();
        var isExpandAll = checkBoxPage.IsExpandAll();
        checkBoxPage.CollapseAllClick();
        var isCollapsAll = checkBoxPage.IsExpandAll();

        Assert.Multiple(() =>
            {
                Assert.True(isExpandAll);
                Assert.False(isCollapsAll);
            });
    }

    [Test]
    public void CheckUrlTitleCheckBoxPage()
    {
        _mainPage.NavigateToPage();
        var elementsPage = _mainPage.ClickOnCardWithName("Elements");
        var checkBoxPage = elementsPage.OpenCheckBox();
        var url = checkBoxPage.GetPageUrl();
        var title = checkBoxPage.GetTitleCheckBox();

        Assert.Multiple(() =>
            {
                Assert.That(url, Is.EqualTo("https://demoqa.com/checkbox"));
                Assert.That(title, Is.EqualTo("Check Box"));
            });
    }

    [Test]
    public void CheckedHome()
    {
         _mainPage.NavigateToPage();
        var elementsPage = _mainPage.ClickOnCardWithName("Elements");
        var checkBoxPage = elementsPage.OpenCheckBox();
        checkBoxPage.CheckHomeClick();
        var result = checkBoxPage.IsDisplayResult();
        var text = checkBoxPage.GetResultText();

        Assert.True(result);
        Assert.That(text, Does.Contain("\nhome\ndesktop\nnotes\ncommands\ndocuments\nworkspace\nreact\nangular\nveu\noffice\npublic\nprivate\nclassified\ngeneral\ndownloads\nwordFile\nexcelFile"));
    }

    [Test]
    public void CheckedAFewItems()
    {
         _mainPage.NavigateToPage();
        var elementsPage = _mainPage.ClickOnCardWithName("Elements");
        var checkBoxPage = elementsPage.OpenCheckBox();
        //TODO: fix
        // checkBoxPage.CheckItemByName("Notes");
        // checkBoxPage.CheckItemByName("Angular");
        // checkBoxPage.CheckItemByName("Veu");
        // checkBoxPage.CheckItemByName("General");
        // var text = checkBoxPage.GetResultText();
        // var homeHalfCheck = checkBoxPage.IsNodeHalfCheck("Home");
        // var desktopHalfCheck = checkBoxPage.IsNodeHalfCheck("Desktop");
        // var workSpaceHalfCheck = checkBoxPage.IsNodeHalfCheck("WorkSpace");
        // var documentsHalfCheck = checkBoxPage.IsNodeHalfCheck("Documents");
        // var generalChecked = checkBoxPage.IsNodeChecked("General");


        // Assert.Multiple(() =>
        //     {
        //         Assert.That(text, Does.Contain("\nnotes\nangular\nveu\ngeneral"));
        //         Assert.True(homeHalfCheck);
        //         Assert.True(desktopHalfCheck);
        //         Assert.True(workSpaceHalfCheck);
        //         Assert.True(documentsHalfCheck);
        //         Assert.True(generalChecked);
        //     });
    }

    [TearDown]
    public void TearDown()
    {
        _mainPage.Close();
    }

}