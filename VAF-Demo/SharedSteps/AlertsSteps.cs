using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Core;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.SharedSteps
{
    /// <summary>Steps for /practice/alerts.</summary>
    public static class AlertsSteps
    {
        public static void LetsOpenTheDialogs() => SharedContext.LetsOpen("/practice/alerts");

        public static void LetsAskToDelete() => LetsClick<AlertsPage.Dialogs.Confirm>();

        public static void LetsAskForAName() => LetsClick<AlertsPage.Dialogs.Prompt>();

        /// <summary>The dialog belongs to the browser, not to the page, so it is reached through Browser.</summary>
        public static void LetsAccept(string question) => SharedContext.Browser.Should().HaveAlert().HaveText(question).Accept();

        public static void LetsDismiss(string question) => SharedContext.Browser.Should().HaveAlert().HaveText(question).Dismiss();

        public static void LetsCheckTheAnswer(string answer)
        {
            SharedContext.App.Should().HaveSection<AlertsPage.ResultLine>()
                .That.Should().HaveElement<AlertsPage.ResultLine.Result>()
                    .That.AsLabelText().Should().HaveValue(answer);
        }

        private static void LetsClick<TButton>() where TButton : IElementContext, new()
        {
            SharedContext.App.Should().HaveSection<AlertsPage.Dialogs>()
                .That.Should().HaveElement<TButton>()
                    .That.AsButton().LetsClick();
        }
    }
}
