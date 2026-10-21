using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary>/practice/loading: results behind a spinner, and a message that appears later.</summary>
    public static class LoadingPage
    {
        /// <summary>The spinner; VAF waits for it to disappear once it is set with LetsUseLoader.</summary>
        public class Spinner : IElementContext
        {
            public By ElementFindMechanism { get; set; } = By.Id("loading-spinner");
        }

        public class SpinnerDemo : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("spinner-demo");

            public class Load : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("load-results");
            }

            public class LoadCount : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("load-count");
            }

            public class FirstResult : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("result-1");
            }
        }

        public class LateDemo : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("late-demo");

            public class Show : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("show-later");
            }

            public class Message : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("late-message");
            }
        }
    }
}
