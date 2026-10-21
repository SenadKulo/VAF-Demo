using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.SharedSteps;

namespace VAF_Demo.Tests.SharedSteps
{
    [Category("SharedSteps")]
    public class AlertsStepsTests : TestBase
    {
        [SetUp]
        public void Open() => AlertsSteps.LetsOpenTheDialogs();

        [Test]
        public void ConfirmAcceptedDeletes()
        {
            AlertsSteps.LetsAskToDelete();
            AlertsSteps.LetsAccept("Delete the item?");
            AlertsSteps.LetsCheckTheAnswer("Deleted");
        }

        [Test]
        public void PromptDismissedGivesNoName()
        {
            AlertsSteps.LetsAskForAName();
            AlertsSteps.LetsDismiss("Your name?");
            AlertsSteps.LetsCheckTheAnswer("No name given");
        }
    }
}
