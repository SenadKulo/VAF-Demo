using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.SharedSteps
{
    /// <summary>Steps for /practice/windows.</summary>
    public static class WindowsSteps
    {
        public static void LetsOpenTheWindowsPage() => SharedContext.LetsOpen("/practice/windows");

        /// <summary>Clicks the link and switches to the tab it opens.</summary>
        public static void LetsOpenTheChildInANewTab()
        {
            SharedContext.App.Should().HaveSection<WindowsPage.Openers>()
                .That.Should().HaveElement<WindowsPage.Openers.NewTab>()
                    .That.AsLink().LetsClick();

            SharedContext.Browser.LetsSwitchToWindow(ChildWindowPage.Title);
        }

        /// <summary>App works in the new tab too: it always looks in the window the browser is on.</summary>
        public static void LetsCheckTheChildWasOpenedBy(string opener)
        {
            SharedContext.App.Should().HaveElement<ChildWindowPage.OpenedBy>()
                .That.AsLabelText().Should().HaveValue("Opened by: " + opener);
        }

        /// <summary>Closes the child tab and checks that the browser is back on the windows page.</summary>
        public static void LetsCloseTheChild()
        {
            SharedContext.Browser.LetsCloseTab(2).LetsSwitchToWindow(1)
                .Should().HaveTitle(WindowsPage.Title);
        }

        public static bool LetsCheckIfTheChildIsOpen() => SharedContext.Browser.LetsCheckIfWindowExists(ChildWindowPage.Title);
    }
}
