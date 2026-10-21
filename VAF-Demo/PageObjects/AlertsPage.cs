using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary>/practice/alerts: buttons that open the browser's dialogs, and a line with the answer.</summary>
    public static class AlertsPage
    {
        public class Dialogs : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("dialog-buttons");

            public class Confirm : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("confirm-button");
            }

            public class Prompt : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("prompt-button");
            }
        }

        public class ResultLine : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("result-line");

            public class Result : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("alert-result");
            }
        }
    }
}
