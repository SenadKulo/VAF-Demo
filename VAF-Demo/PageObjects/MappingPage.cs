using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary>
    /// <see href="https://www.visionautomationframework.com/practice/mapping">/practice/mapping</see>, section A:
    /// built for testing. An id on every single element, data-test on the ones that repeat; both stay
    /// the same in version 2, after the redesign.
    /// </summary>
    public static class MappingPage
    {
        public class Order : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("order-stable");

            public class Status : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("order-status");
            }

            /// <summary>The name cell of every item row: the rows repeat, so data-test instead of an id.</summary>
            public class ItemName : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("[data-test='order-item'] [data-test='item-name']");
            }

            public class Total : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("order-total");
            }

            public class Note : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("courier-note");
            }

            public class SaveNote : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("save-note");
            }

            public class Cancel : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("cancel-order");
            }

            public class Message : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("order-message");
            }
        }
    }
}
