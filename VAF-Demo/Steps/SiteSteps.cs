using System;
using VAF_Demo.PageObjects;
using VisionAutomationFramework;
using VisionAutomationFramework.Actions;
using VisionAutomationFramework.Browsers;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.Steps
{
    /// <summary>
    /// Layer 2 — shared steps. Each step wraps a fluent chain into one business action, starting from the
    /// saved page context. Tests call steps, so a changed page means one changed step, not every test.
    /// </summary>
    public static class SiteSteps
    {
        /// <summary>
        /// The site under test. Set VAF_DEMO_BASE_URL to run against another copy, e.g. a local one
        /// (http://localhost:5199), where the contact form can really be sent.
        /// </summary>
        public static string BaseUrl { get; } =
            (Environment.GetEnvironmentVariable("VAF_DEMO_BASE_URL") ?? "http://www.visionautomationframework.com").TrimEnd('/');

        public static BrowserActions Browser { get; private set; }

        public static PageActions<VafSite> Site { get; private set; }

        public static void LetsOpen(string path = "/")
        {
            Browser = Testing.On<Chrome>();
            Site = Browser.LetsNavigateTo(BaseUrl + path)
                .Should().DisplayPage<VafSite>().That;
        }

        public static void LetsGoToQuickStartFromTheMenu()
        {
            Site.Should().HaveSection<VafSite.Navigation>()
                .That.Should().HaveElement<VafSite.Navigation.QuickStart>()
                    .That.AsLink().LetsClick();
        }

        public static void LetsGoToContactFromTheMenu()
        {
            Site.Should().HaveSection<VafSite.Navigation>()
                .That.Should().HaveElement<VafSite.Navigation.Contact>()
                    .That.AsLink().LetsClick();
        }

        public static void LetsOpenTheBetaPageFromQuickStart()
        {
            Site.Should().HaveSection<VafSite.QuickStartSteps>()
                .That.Should().HaveElement<VafSite.QuickStartSteps.BetaLink>()
                    .That.AsLink().LetsClick();
        }

        public static void LetsCheckThePageTitle(string title)
        {
            Site.Should().HaveSection<VafSite.PageHeader>()
                .That.Should().HaveElement<VafSite.PageHeader.Title>()
                    .That.AsLabelText().Should().HaveValue(title);
        }

        public static void LetsFillTheContactForm(string name, string email, string topic, string message)
        {
            Site.Should().HaveSection<VafSite.ContactForm>()
                .That.Should().HaveElement<VafSite.ContactForm.Name>()
                    .That.AsTextInputField().LetsInsert(name)
                .AndAlso().Should().HaveElement<VafSite.ContactForm.Email>()
                    .That.AsTextInputField().LetsInsert(email)
                .AndAlso().Should().HaveElement<VafSite.ContactForm.Topic>()
                    .That.AsSelectBox().LetsSelect(topic)
                .AndAlso().Should().HaveElement<VafSite.ContactForm.Message>()
                    .That.AsTextAreaField().LetsInsert(message);
        }

        public static void LetsSendTheContactForm()
        {
            Site.Should().HaveSection<VafSite.ContactForm>()
                .That.Should().HaveElement<VafSite.ContactForm.Send>()
                    .That.AsButton().LetsClick();
        }

        public static void LetsCloseTheBrowser() => Browser?.Scope.Driver.Quit();
    }
}
