using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary>
    /// /practice/date-pickers-bootstrap3: a page with its own Bootstrap 3 layout, so it has no
    /// breadcrumb or page header. The VAF element is the picker's div.input-group.date.
    /// </summary>
    public static class Bootstrap3DatePickerPage
    {
        public class Start : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("start-section");

            public class Picker : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("start-date");
            }

            public class Selected : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("start-date-value");
            }
        }
    }
}
