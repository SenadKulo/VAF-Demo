using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary>/practice/context-menu: a menu the page draws on right click.</summary>
    public static class ContextMenuPage
    {
        public class PageMenu : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("custom-menu-demo");

            public class Area : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("context-area");
            }

            public class Rename : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("custom-rename");
            }

            public class Result : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("context-result");
            }
        }
    }
}
