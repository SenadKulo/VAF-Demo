using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary>/practice/forms: a sign-up form that shows back what it received.</summary>
    public static class FormsPage
    {
        /// <summary>The form, with the error messages the server puts next to the fields.</summary>
        public class Registration : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("registration");

            public class FullName : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("full-name");
            }

            public class Email : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("email");
            }

            public class Password : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("password");
            }

            public class Country : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("country");
            }

            public class PlanFree : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("plan-free");
            }

            public class PlanTeam : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("plan-team");
            }

            public class PlanEnterprise : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("plan-enterprise");
            }

            public class AcceptTerms : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("accept-terms");
            }

            public class Submit : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("submit-button");
            }

            public class ErrorCount : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("error-count");
            }

            public class FullNameError : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("full-name-error");
            }

            public class EmailError : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("email-error");
            }

            public class PasswordError : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("password-error");
            }

            public class CountryError : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("country-error");
            }
        }

        /// <summary>What the server received, shown after a valid form is sent.</summary>
        public class Result : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("result");

            public class Title : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("result-title");
            }

            public class FullName : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("result-full-name");
            }

            public class Email : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("result-email");
            }

            public class Country : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("result-country");
            }

            public class Plan : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("result-plan");
            }
        }
    }
}
