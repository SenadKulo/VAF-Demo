using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.Tests.Site
{
    /// <summary>
    /// The same approach on the site's own pages, which were not made for testing: the locators
    /// are CSS selectors and link texts instead of ids, and the tests follow the site's text.
    /// </summary>
    [Category("Site")]
    public class SiteTests : TestBase
    {
        [SetUp]
        public void OpenHome() => SharedContext.LetsOpen("/");

        [Test]
        public void HomeLeadsToTheQuickStartGuide()
        {
            SharedContext.App.Should().HaveSection<VafSite.Hero>()
                .That.Should().HaveElement<VafSite.Hero.Title>()
                    .That.AsLabelText().Should().HaveValue("The easy way to automate tests.");

            SharedContext.App.Should().HaveSection<VafSite.Navigation>()
                .That.Should().HaveElement<VafSite.Navigation.QuickStart>()
                    .That.AsLink().LetsClick();

            SharedContext.App.Should().HaveSection<VafSite.PageHeader>()
                .That.Should().HaveElement<VafSite.PageHeader.Title>()
                    .That.AsLabelText().Should().HaveValue("Quick start guide");
        }

        /// <summary>
        /// The server rejects an empty form, so nothing is sent. (The site accepts at most 5 contact
        /// forms per address in 10 minutes; one run sends it once.)
        /// </summary>
        [Test]
        public void EmptyContactFormShowsWhatIsMissing()
        {
            // A real site may ask about cookies first, and the question can cover the button the
            // test wants to click. This site asks only where analytics is on (not on a local copy),
            // so the test first counts the banners in the page. The practice pages never ask.
            if (SharedContext.App.LetsGetCountOfElements<VafSite.ConsentBanner.Decline>() > 0)
            {
                SharedContext.App.Should().HaveSection<VafSite.ConsentBanner>()
                    .That.Should().HaveElement<VafSite.ConsentBanner.Decline>()
                        .That.AsButton().LetsClick();
            }

            SharedContext.App.Should().HaveSection<VafSite.Navigation>()
                .That.Should().HaveElement<VafSite.Navigation.Contact>()
                    .That.AsLink().LetsClick();

            // The form's section is <main>, which every page has; checking the title first makes
            // sure the contact page is the one shown.
            SharedContext.App.Should().HaveSection<VafSite.PageHeader>()
                .That.Should().HaveElement<VafSite.PageHeader.Title>()
                    .That.AsLabelText().Should().HaveValue("Contact");

            SharedContext.App.Should().HaveSection<VafSite.ContactForm>()
                .That.Should().HaveElement<VafSite.ContactForm.Send>()
                    .That.AsButton().LetsClick();

            // Sending loads the contact page again, and its <main> is on both the old and the new
            // page. A page-level HaveElement waits until the first message is shown, i.e. until the
            // new page is there; then the section can be checked.
            SharedContext.App.Should().HaveElement<VafSite.ContactForm.NameError>()
                .That.AsLabelText().Should().HaveValue("Please enter your name.");

            SharedContext.App.Should().HaveSection<VafSite.ContactForm>()
                .That.Should().HaveElement<VafSite.ContactForm.EmailError>()
                    .That.AsLabelText().Should().HaveValue("Please enter your email address.")
                .AndAlso().Should().HaveElement<VafSite.ContactForm.MessageError>()
                    .That.AsLabelText().Should().HaveValue("Please write a message.");
        }
    }
}
