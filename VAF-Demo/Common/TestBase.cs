using NUnit.Framework;
using NUnit.Framework.Interfaces;
using VisionAutomationFramework;

namespace VAF_Demo.Common
{
    /// <summary>
    /// The base of every test class: the life of the browser, in one place.
    /// [SetUp] starts Chrome before each test, [TearDown] reports and closes it after the test.
    /// A test class adds only what is its own, usually a [SetUp] that opens its page with
    /// SharedContext.LetsOpen (NUnit runs this [SetUp] first, then the test class's).
    /// </summary>
    public abstract class TestBase
    {
        [SetUp]
        public void StartTheBrowser() => SharedContext.LetsStartTheBrowser();

        [TearDown]
        public void ReportAndClose()
        {
            try
            {
                // A failed test leaves a screenshot; every test leaves an HTML report of what VAF did,
                // both in the test output folder.
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    SharedContext.Browser?.LetsTakeScreenshot();
                }

                Testing.ConvertLogToHtml(TestContext.CurrentContext.WorkDirectory,
                                         TestContext.CurrentContext.Test.Name);
            }
            finally
            {
                // Always close the browser and clear the shared state, even when the report cannot
                // be written; the next test starts from nothing.
                SharedContext.LetsCloseTheBrowser();
            }
        }
    }
}
