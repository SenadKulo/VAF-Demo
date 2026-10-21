using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary>/practice/windows/child: the page that opens in the new tab.</summary>
    public static class ChildWindowPage
    {
        public const string Title = "Practice: child window — Vision Automation Framework";

        /// <summary>"Opened by: link" — an element straight on the page, without a section.</summary>
        public class OpenedBy : IElementContext
        {
            public By ElementFindMechanism { get; set; } = By.Id("opened-by");
        }
    }
}
