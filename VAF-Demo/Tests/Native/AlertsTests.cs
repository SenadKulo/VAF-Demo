using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.Tests.Native
{
    /// <summary>The browser's own dialogs: confirm and prompt.</summary>
    [Category("Native")]
    public class AlertsTests : TestBase
    {
        [SetUp]
        public void Open() => SharedContext.LetsOpen("/practice/alerts");

        [Test]
        public void ConfirmAcceptedDeletes()
        {
            SharedContext.App.Should().HaveSection<AlertsPage.Dialogs>()
                .That.Should().HaveElement<AlertsPage.Dialogs.Confirm>()
                    .That.AsButton().LetsClick();

            // The dialog belongs to the browser, not to the page.
            SharedContext.Browser.Should().HaveAlert().HaveText("Delete the item?").Accept();

            SharedContext.App.Should().HaveSection<AlertsPage.ResultLine>()
                .That.Should().HaveElement<AlertsPage.ResultLine.Result>()
                    .That.AsLabelText().Should().HaveValue("Deleted");
        }

        [Test]
        public void PromptDismissedGivesNoName()
        {
            SharedContext.App.Should().HaveSection<AlertsPage.Dialogs>()
                .That.Should().HaveElement<AlertsPage.Dialogs.Prompt>()
                    .That.AsButton().LetsClick();

            SharedContext.Browser.Should().HaveAlert().HaveText("Your name?").Dismiss();

            SharedContext.App.Should().HaveSection<AlertsPage.ResultLine>()
                .That.Should().HaveElement<AlertsPage.ResultLine.Result>()
                    .That.AsLabelText().Should().HaveValue("No name given");
        }
    }
}
