using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Core;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.SharedSteps
{
    /// <summary>
    /// Level 2 — shared steps. Each step wraps a fluent chain into one business action or check, so
    /// a test reads as what the user does. These steps move between the practice pages.
    /// </summary>
    public static class PracticeSteps
    {
        public static void LetsOpenTheOverview() => SharedContext.LetsOpen("/practice");

        public static void LetsGoToForms() => LetsFollowTheCard<OverviewPage.Cards.Forms>();

        public static void LetsGoToTables() => LetsFollowTheCard<OverviewPage.Cards.Tables>();

        public static void LetsGoToDatePickers() => LetsFollowTheCard<OverviewPage.Cards.DatePickers>();

        public static void LetsGoToWindows() => LetsFollowTheCard<OverviewPage.Cards.Windows>();

        /// <summary>Back to /practice through the breadcrumb, from any practice page.</summary>
        public static void LetsGoBackToTheOverview()
        {
            SharedContext.App.Should().HaveSection<PracticeLayout.Breadcrumb>()
                .That.Should().HaveElement<PracticeLayout.Breadcrumb.PracticePages>()
                    .That.AsLink().LetsClick();
        }

        public static void LetsCheckThePageTitle(string title)
        {
            SharedContext.App.Should().HaveSection<PracticeLayout.PageHeader>()
                .That.Should().HaveElement<PracticeLayout.PageHeader.Title>()
                    .That.AsLabelText().Should().HaveValue(title);
        }

        private static void LetsFollowTheCard<TCard>() where TCard : IElementContext, new()
        {
            SharedContext.App.Should().HaveSection<OverviewPage.Cards>()
                .That.Should().HaveElement<TCard>()
                    .That.AsLink().LetsClick();
        }
    }
}
