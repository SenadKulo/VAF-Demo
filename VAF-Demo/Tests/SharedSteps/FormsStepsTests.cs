using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.SharedSteps;

namespace VAF_Demo.Tests.SharedSteps
{
    /// <summary>
    /// Level 2 — the same tests as in Tests/Native, written with shared steps. A test reads as what
    /// the user does; how it is done on the page lives in one step.
    /// </summary>
    [Category("SharedSteps")]
    public class FormsStepsTests : TestBase
    {
        // TestBase has started Chrome; the step goes to the page and fills SharedContext.App.
        [SetUp]
        public void Open() => FormsSteps.LetsOpenTheForm();

        [Test]
        public void ValidRegistrationIsShownBack()
        {
            FormsSteps.LetsRegister("Ada Lovelace", "ada@example.com", "analytical", "Croatia", plan: "Team");
            FormsSteps.LetsCheckTheResult("Ada Lovelace", "ada@example.com", "Croatia", plan: "Team");
        }

        [Test]
        public void EmptyFormShowsAnErrorPerField()
        {
            FormsSteps.LetsSendTheEmptyForm();
            FormsSteps.LetsCheckThatEveryRequiredFieldIsReported();
        }
    }
}
