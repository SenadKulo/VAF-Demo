using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary>
    /// <see href="https://www.visionautomationframework.com/practice/mapping">/practice/mapping</see>, section B:
    /// built without testing in mind. DON'T MAP A PAGE LIKE THIS — every locator below works today and
    /// breaks with the redesign of version 2 (/practice/mapping?version=2). Each one says why. If a
    /// page gives you only such locators, ask its developers for an id or a data-test attribute.
    /// </summary>
    public static class MappingPageFragile
    {
        /// <summary>By text: version 2 says "Your order 1042". Texts get reworded and translated.</summary>
        public class Title : IElementContext
        {
            public By ElementFindMechanism { get; set; } = By.XPath("//span[text()='Order #1042']");
        }

        /// <summary>By a generated class: the styling library makes new ones with every build.</summary>
        public class Status : IElementContext
        {
            public By ElementFindMechanism { get; set; } = By.CssSelector(".css-1x9f3k");
        }

        /// <summary>By position: version 2 lists the items in another order, so "the third row" is another item.</summary>
        public class ThirdItemName : IElementContext
        {
            public By ElementFindMechanism { get; set; } = By.XPath("(//div[contains(@class,'d-flex gap-2 border-bottom')])[3]/div[1]/span");
        }

        /// <summary>An absolute XPath, as the browser's developer tools copy it: anything that moves above it breaks it.</summary>
        public class Total : IElementContext
        {
            public By ElementFindMechanism { get; set; } = By.XPath("/html/body/main/div/div[1]/div[2]/section/div/div/div[4]/div/span[2]");
        }
    }
}
