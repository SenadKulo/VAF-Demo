using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using VAF_Demo.PageObjects;
using VAF_Demo.Steps;
using VisionAutomationFramework;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.Tests
{
    /// <summary>
    /// Layer 3 — tests. Short, they read as the steps they call. The browser opens before and
    /// closes after each test; a failed test leaves a screenshot and an HTML report.
    /// </summary>
    public abstract class SiteTest
    {
        [TearDown]
        public void Report()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                SiteSteps.Browser?.LetsTakeScreenshot();
            }

            Testing.ConvertLogToHtml(TestContext.CurrentContext.WorkDirectory,
                                     TestContext.CurrentContext.Test.Name);
            SiteSteps.LetsCloseTheBrowser();
        }
    }

    public class NavigationTests : SiteTest
    {
        [SetUp]
        public void OpenHome() => SiteSteps.LetsOpen();

        [Test]
        public void HomeShowsTheHeroAndTheFeatures()
        {
            SiteSteps.Site.Should().HaveSection<VafSite.Hero>()
                .That.Should().HaveElement<VafSite.Hero.Title>()
                    .That.AsLabelText().Should().HaveValue("The easy way to automate tests.");

            SiteSteps.Site.Should().HaveSection<VafSite.Features>()
                .That.Should().HaveElement<VafSite.Features.Title>()
                    .That.AsLabelText().Should().HaveValue("Why VAF");
        }

        [Test]
        public void MenuOpensTheQuickStartGuide()
        {
            SiteSteps.LetsGoToQuickStartFromTheMenu();
            SiteSteps.LetsCheckThePageTitle("Quick start guide");

            SiteSteps.Site.Should().HaveSection<VafSite.QuickStartSteps>()
                .That.Should().HaveElement<VafSite.QuickStartSteps.FirstStep>()
                    .That.AsLabelText().Should().HaveValue("Install Visual Studio and Chrome");
        }

        [Test]
        public void QuickStartLinksToTheBetaPage()
        {
            SiteSteps.LetsGoToQuickStartFromTheMenu();
            SiteSteps.LetsOpenTheBetaPageFromQuickStart();
            SiteSteps.LetsCheckThePageTitle("VAF 3.0 beta");
        }

        [Test]
        public void GuideContentsJumpToAChapter()
        {
            SiteSteps.Browser.LetsNavigateTo(SiteSteps.BaseUrl + "/guide");

            SiteSteps.Site.Should().HaveSection<VafSite.GuideContents>()
                .That.Should().HaveElement<VafSite.GuideContents.Tests>()
                    .That.AsLink().LetsClick();

            Assert.That(SiteSteps.Browser.Scope.Driver.Url, Does.EndWith("/guide#tests"));
        }
    }

    public class ContactFormTests : SiteTest
    {
        [SetUp]
        public void OpenContact()
        {
            SiteSteps.LetsOpen();
            SiteSteps.LetsGoToContactFromTheMenu();
            SiteSteps.LetsCheckThePageTitle("Contact");
        }

        // The form is checked on the server; an invalid form is never sent, so these tests are
        // safe to run against the live site.

        [Test]
        public void EmptyFormShowsWhatIsMissing()
        {
            SiteSteps.LetsSendTheContactForm();

            SiteSteps.LetsCheckContactFormMessage<VafSite.ContactForm.NameError>("Please enter your name.");
            SiteSteps.LetsCheckContactFormMessage<VafSite.ContactForm.EmailError>("Please enter your email address.");
            SiteSteps.LetsCheckContactFormMessage<VafSite.ContactForm.MessageError>("Please write a message.");
        }

        [Test]
        public void InvalidEmailAndShortMessageAreRejected()
        {
            SiteSteps.LetsFillTheContactForm("VAF Demo", "not-an-email", "Suggestion", "Too short");
            SiteSteps.LetsSendTheContactForm();

            SiteSteps.LetsCheckContactFormMessage<VafSite.ContactForm.EmailError>("This does not look like an email address.");
            SiteSteps.LetsCheckContactFormMessage<VafSite.ContactForm.MessageError>("The message should be between 10 and 5000 characters.");
        }

        [Test]
        public void ValidFormIsSent()
        {
            // A valid form sends a real email, so this test runs only against a local copy of the
            // site (VAF_DEMO_BASE_URL=http://localhost:…), which in Development writes the mail to a
            // file instead of sending it.
            if (!new Uri(SiteSteps.BaseUrl).IsLoopback)
            {
                Assert.Ignore("Sends a real email; runs only against a local site (set VAF_DEMO_BASE_URL).");
            }

            SiteSteps.LetsFillTheContactForm("VAF Demo", "vaf-demo@example.com", "Suggestion",
                "Message from the VAF demo, " + DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            SiteSteps.LetsSendTheContactForm();

            SiteSteps.Site.Should().HaveSection<VafSite.ContactForm>()
                .That.Should().HaveElement<VafSite.ContactForm.SentConfirmation>()
                    .That.AsLabelText().Should().Contain("your message has been sent");
        }
    }
}
