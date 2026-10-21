using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.Tests.Native
{
    /// <summary>
    /// Level 1 — native: the whole VAF chain is written in the test. App → section → element →
    /// control type → action or check; AndAlso() goes on with the next element of the same section.
    /// </summary>
    [Category("Native")]
    public class FormsTests : TestBase
    {
        // TestBase has started Chrome; this goes to the forms page and fills the shared page
        // context, SharedContext.App, which every chain below starts from.
        [SetUp]
        public void Open() => SharedContext.LetsOpen("/practice/forms");

        [Test]
        public void ValidRegistrationIsShownBack()
        {
            SharedContext.App.Should().HaveSection<FormsPage.Registration>()
                .That.Should().HaveElement<FormsPage.Registration.FullName>()
                    .That.AsTextInputField().LetsInsert("Ada Lovelace")
                .AndAlso().Should().HaveElement<FormsPage.Registration.Email>()
                    .That.AsTextInputField().LetsInsert("ada@example.com")
                .AndAlso().Should().HaveElement<FormsPage.Registration.Password>()
                    .That.AsTextInputField().LetsInsert("analytical")
                .AndAlso().Should().HaveElement<FormsPage.Registration.Country>()
                    .That.AsSelectBox().LetsSelect("Croatia")
                .AndAlso().Should().HaveElement<FormsPage.Registration.PlanTeam>()
                    .That.AsRadioButton().LetsClick()
                .AndAlso().Should().HaveElement<FormsPage.Registration.AcceptTerms>()
                    .That.AsCheckBox().LetsClick()
                .AndAlso().Should().HaveElement<FormsPage.Registration.Submit>()
                    .That.AsButton().LetsClick();

            SharedContext.App.Should().HaveSection<FormsPage.Result>()
                .That.Should().HaveElement<FormsPage.Result.Title>()
                    .That.AsLabelText().Should().HaveValue("Registration received")
                .AndAlso().Should().HaveElement<FormsPage.Result.FullName>()
                    .That.AsLabelText().Should().HaveValue("Ada Lovelace")
                .AndAlso().Should().HaveElement<FormsPage.Result.Email>()
                    .That.AsLabelText().Should().HaveValue("ada@example.com")
                .AndAlso().Should().HaveElement<FormsPage.Result.Country>()
                    .That.AsLabelText().Should().HaveValue("Croatia")
                .AndAlso().Should().HaveElement<FormsPage.Result.Plan>()
                    .That.AsLabelText().Should().HaveValue("Team");
        }

        [Test]
        public void EmptyFormShowsAnErrorPerField()
        {
            // The button stays disabled until the terms are accepted.
            SharedContext.App.Should().HaveSection<FormsPage.Registration>()
                .That.Should().HaveElement<FormsPage.Registration.Submit>()
                    .That.AsButton().Should().BeDisabled()
                .AndAlso().Should().HaveElement<FormsPage.Registration.AcceptTerms>()
                    .That.AsCheckBox().LetsClick()
                .AndAlso().Should().HaveElement<FormsPage.Registration.Submit>()
                    .That.AsButton().LetsClick();

            SharedContext.App.Should().HaveSection<FormsPage.Registration>()
                .That.Should().HaveElement<FormsPage.Registration.ErrorCount>()
                    .That.AsCounterField().Should().HaveValue("4")
                .AndAlso().Should().HaveElement<FormsPage.Registration.FullNameError>()
                    .That.AsLabelText().Should().HaveValue("Please enter your full name.")
                .AndAlso().Should().HaveElement<FormsPage.Registration.EmailError>()
                    .That.AsLabelText().Should().HaveValue("Please enter your email address.")
                .AndAlso().Should().HaveElement<FormsPage.Registration.PasswordError>()
                    .That.AsLabelText().Should().HaveValue("Please choose a password.")
                .AndAlso().Should().HaveElement<FormsPage.Registration.CountryError>()
                    .That.AsLabelText().Should().HaveValue("Please choose a country.");
        }
    }
}
