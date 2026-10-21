using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary><see href="https://www.visionautomationframework.com/practice/navigation">/practice/navigation</see>: a drop-down menu and tabs.</summary>
    public static class NavigationPage
    {
        public class AccountMenu : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("menu-demo");

            public class Open : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("menu-button");
            }

            public class Settings : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("menu-settings");
            }

            public class Result : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("menu-result");
            }
        }

        public class Tabs : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("tabs-demo");

            public class Specifications : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("tab-specs");
            }

            public class Archive : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("tab-archive");
            }

            public class OverviewPane : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("pane-overview");
            }

            public class SpecificationsPane : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("pane-specs");
            }
        }
    }
}
