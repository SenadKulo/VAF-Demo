using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary>/practice/date-pickers: flatpickr 4. The VAF element is flatpickr's wrapper around the input.</summary>
    public static class DatePickersPage
    {
        public class Single : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("single-demo");

            public class Birthday : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("#birthday-field .flatpickr-wrapper");
            }

            public class Selected : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("birthday-value");
            }
        }

        /// <summary>Two calendars that start in different years, and the number of days between them.</summary>
        public class Range : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("range-demo");

            public class From : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("#from-field .flatpickr-wrapper");
            }

            public class To : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("#to-field .flatpickr-wrapper");
            }

            public class Days : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("range-days");
            }
        }
    }
}
