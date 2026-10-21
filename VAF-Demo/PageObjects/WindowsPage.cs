using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary>/practice/windows: a link that opens a new tab.</summary>
    public static class WindowsPage
    {
        /// <summary>The browser title of this page; windows are found by title.</summary>
        public const string Title = "Practice: windows and tabs — Vision Automation Framework";

        public class Openers : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("openers");

            public class NewTab : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("open-tab");
            }
        }
    }
}
