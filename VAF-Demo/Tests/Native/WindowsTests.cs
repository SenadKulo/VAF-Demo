using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.Tests.Native
{
    /// <summary>A link that opens a new tab: find the tab, read it, close it.</summary>
    [Category("Native")]
    public class WindowsTests : TestBase
    {
        [SetUp]
        public void Open() => SharedContext.LetsOpen("/practice/windows");

        [Test]
        public void NewTabIsFoundReadAndClosed()
        {
            SharedContext.App.Should().HaveSection<WindowsPage.Openers>()
                .That.Should().HaveElement<WindowsPage.Openers.NewTab>()
                    .That.AsLink().LetsClick();

            // Windows and tabs are found by their title (or address, or number). App then looks in
            // the window the browser has switched to.
            SharedContext.Browser.LetsSwitchToWindow(ChildWindowPage.Title);

            SharedContext.App.Should().HaveElement<ChildWindowPage.OpenedBy>()
                .That.AsLabelText().Should().HaveValue("Opened by: link");

            SharedContext.Browser.LetsCloseTab(2).LetsSwitchToWindow(1)
                .Should().HaveTitle(WindowsPage.Title);

            Assert.That(SharedContext.Browser.LetsCheckIfWindowExists(ChildWindowPage.Title), Is.False);
        }
    }
}
