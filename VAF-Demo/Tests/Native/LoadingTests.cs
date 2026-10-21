using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.Tests.Native
{
    /// <summary>No waits in the tests: VAF waits for the loader and for elements by itself.</summary>
    [Category("Native")]
    public class LoadingTests : TestBase
    {
        [SetUp]
        public void Open() => SharedContext.LetsOpen("/practice/loading");

        [Test]
        public void ResultsAreReadAfterTheLoaderIsGone()
        {
            // From now on VAF waits for the spinner to disappear before it looks for an element.
            SharedContext.Browser.LetsUseLoader<LoadingPage.Spinner>();

            SharedContext.App.Should().HaveSection<LoadingPage.SpinnerDemo>()
                .That.Should().HaveElement<LoadingPage.SpinnerDemo.Load>()
                    .That.AsButton().LetsClick();

            // The counter is on the page from the start ("0"); it reads "1" only once the results
            // are in, so the check would fail without the loader.
            SharedContext.App.Should().HaveSection<LoadingPage.SpinnerDemo>()
                .That.Should().HaveElement<LoadingPage.SpinnerDemo.LoadCount>()
                    .That.AsCounterField().Should().HaveValue("1")
                .AndAlso().Should().HaveElement<LoadingPage.SpinnerDemo.FirstResult>()
                    .That.AsLabelText().Should().HaveValue("Alpha (load 1)");
        }

        [Test]
        public void LateMessageIsWaitedFor()
        {
            // The message appears two seconds after the click; HaveElement waits for it.
            SharedContext.App.Should().HaveSection<LoadingPage.LateDemo>()
                .That.Should().HaveElement<LoadingPage.LateDemo.Show>()
                    .That.AsButton().LetsClick()
                .AndAlso().Should().HaveElement<LoadingPage.LateDemo.Message>()
                    .That.AsLabelText().Should().HaveValue("Here I am, two seconds later.");
        }
    }
}
