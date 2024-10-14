using Tests.Utils.Swd.PageObjects;
using static Tests.Utils.Swd.Browser.BrowserNames;

namespace Tests.NUnit.Ui.PagesTests;

[TestFixture]
public class CheckBoxPageTests
{
    private CheckBoxPage _checkBoxPage;

    [SetUp]
    public void Setup()
    {
        _checkBoxPage = new CheckBoxPage();
        _checkBoxPage.OpenInBrowser(Firefox, "--start-maximized");
        _checkBoxPage.NavigateToPage();
    }

    [Test]
    public void ExpandAndCollapsAll()
    {
        _checkBoxPage.ExpandAllClick();
        var isExpandAll = _checkBoxPage.IsExpandAll();
        _checkBoxPage.CollapseAllClick();
        var isCollapsAll = _checkBoxPage.IsExpandAll();

        Assert.Multiple(() =>
            {
                Assert.True(isExpandAll);
                Assert.False(isCollapsAll);
            });
    }

    [Test]
    public void CheckUrlTitleCheckBoxPage()
    {
        
        var url = _checkBoxPage.GetPageUrl();
        var title = _checkBoxPage.GetTitleCheckBox();

        Assert.Multiple(() =>
            {
                Assert.That(url, Is.EqualTo("https://demoqa.com/checkbox"));
                Assert.That(title, Is.EqualTo("Check Box"));
            });
    }

    [Test]
    public void CheckedHome()
    {
       
        _checkBoxPage.CheckHomeClick();
        var result = _checkBoxPage.IsDisplayResult();
        var text = _checkBoxPage.GetResultText();

        Assert.True(result);
        Assert.That(text, Does.Contain("\nhome\ndesktop\nnotes\ncommands\ndocuments\nworkspace\nreact\nangular\nveu\noffice\npublic\nprivate\nclassified\ngeneral\ndownloads\nwordFile\nexcelFile"));
    }

    [Test]
    public void CheckedAFewItems()
    {
        _checkBoxPage.CheckItemByName("Notes");
        _checkBoxPage.CheckItemByName("Angular");
        _checkBoxPage.CheckItemByName("Veu");
        _checkBoxPage.CheckItemByName("General");
        var text = _checkBoxPage.GetResultText();

          Assert.That(text, Does.Contain("\nnotes\nangular\nveu\ngeneral"));
    }

    [TearDown]
    public void TearDown()
    {
        _checkBoxPage.Close();
    }

}