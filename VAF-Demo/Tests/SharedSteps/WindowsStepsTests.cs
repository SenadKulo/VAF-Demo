using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.SharedSteps;

namespace VAF_Demo.Tests.SharedSteps
{
    [Category("SharedSteps")]
    public class WindowsStepsTests : TestBase
    {
        [SetUp]
        public void Open() => WindowsSteps.LetsOpenTheWindowsPage();

        [Test]
        public void NewTabIsFoundReadAndClosed()
        {
            WindowsSteps.LetsOpenTheChildInANewTab();
            WindowsSteps.LetsCheckTheChildWasOpenedBy("link");
            WindowsSteps.LetsCloseTheChild();

            Assert.That(WindowsSteps.LetsCheckIfTheChildIsOpen(), Is.False);
        }
    }
}
