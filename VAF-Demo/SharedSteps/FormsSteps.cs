using System;
using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Core;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.SharedSteps
{
    /// <summary>Steps for /practice/forms.</summary>
    public static class FormsSteps
    {
        public static void LetsOpenTheForm() => SharedContext.LetsOpen("/practice/forms");

        /// <summary>Fills in the form, accepts the terms and sends it. plan is Free, Team or Enterprise.</summary>
        public static void LetsRegister(string fullName, string email, string password, string country, string plan)
        {
            SharedContext.App.Should().HaveSection<FormsPage.Registration>()
                .That.Should().HaveElement<FormsPage.Registration.FullName>()
                    .That.AsTextInputField().LetsInsert(fullName)
                .AndAlso().Should().HaveElement<FormsPage.Registration.Email>()
                    .That.AsTextInputField().LetsInsert(email)
                .AndAlso().Should().HaveElement<FormsPage.Registration.Password>()
                    .That.AsTextInputField().LetsInsert(password)
                .AndAlso().Should().HaveElement<FormsPage.Registration.Country>()
                    .That.AsSelectBox().LetsSelect(country);

            // Each plan is its own radio button; the test only names the plan.
            switch (plan)
            {
                case "Free": LetsChooseThePlan<FormsPage.Registration.PlanFree>(); break;
                case "Team": LetsChooseThePlan<FormsPage.Registration.PlanTeam>(); break;
                case "Enterprise": LetsChooseThePlan<FormsPage.Registration.PlanEnterprise>(); break;
                default: throw new ArgumentException("No such plan: " + plan, nameof(plan));
            }

            LetsAcceptTheTermsAndSend();
        }

        public static void LetsSendTheEmptyForm() => LetsAcceptTheTermsAndSend();

        public static void LetsCheckTheResult(string fullName, string email, string country, string plan)
        {
            SharedContext.App.Should().HaveSection<FormsPage.Result>()
                .That.Should().HaveElement<FormsPage.Result.Title>()
                    .That.AsLabelText().Should().HaveValue("Registration received")
                .AndAlso().Should().HaveElement<FormsPage.Result.FullName>()
                    .That.AsLabelText().Should().HaveValue(fullName)
                .AndAlso().Should().HaveElement<FormsPage.Result.Email>()
                    .That.AsLabelText().Should().HaveValue(email)
                .AndAlso().Should().HaveElement<FormsPage.Result.Country>()
                    .That.AsLabelText().Should().HaveValue(country)
                .AndAlso().Should().HaveElement<FormsPage.Result.Plan>()
                    .That.AsLabelText().Should().HaveValue(plan);
        }

        public static void LetsCheckThatEveryRequiredFieldIsReported()
        {
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

        private static void LetsChooseThePlan<TPlan>() where TPlan : IElementContext, new()
        {
            SharedContext.App.Should().HaveSection<FormsPage.Registration>()
                .That.Should().HaveElement<TPlan>()
                    .That.AsRadioButton().LetsClick();
        }

        private static void LetsAcceptTheTermsAndSend()
        {
            SharedContext.App.Should().HaveSection<FormsPage.Registration>()
                .That.Should().HaveElement<FormsPage.Registration.AcceptTerms>()
                    .That.AsCheckBox().LetsClick()
                .AndAlso().Should().HaveElement<FormsPage.Registration.Submit>()
                    .That.AsButton().LetsClick();
        }
    }
}
