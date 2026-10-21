using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary>The sections every practice page has: the breadcrumb bar and the page header.</summary>
    public static class PracticeLayout
    {
        /// <summary>"Home / Practice pages / Forms" under the menu.</summary>
        public class Breadcrumb : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("practice-breadcrumb");

            public class PracticePages : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.LinkText("Practice pages");
            }
        }

        /// <summary>The band with the page title.</summary>
        public class PageHeader : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.CssSelector("section.page-header");

            public class Title : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.TagName("h1");
            }
        }
    }
}
