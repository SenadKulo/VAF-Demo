using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary><see href="https://www.visionautomationframework.com/practice">/practice</see>: a card for every practice page.</summary>
    public static class OverviewPage
    {
        public class Cards : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("practice-pages");

            public class Forms : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("#practice-forms a");
            }

            public class Tables : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("#practice-tables a");
            }

            public class DatePickers : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("#practice-date-pickers a");
            }

            public class Windows : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("#practice-windows a");
            }
        }
    }
}
