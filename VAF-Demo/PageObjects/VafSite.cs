using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary>
    /// The site's own pages (home, Quick start, contact), which were not made for testing: the
    /// locators are CSS selectors and link texts. Found, like every screen, in AppPage.
    /// </summary>
    public static class VafSite
    {
        /// <summary>The green menu bar at the top of every page.</summary>
        public class Navigation : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.CssSelector("nav.site-nav");

            public class QuickStart : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.LinkText("Quick start");
            }

            public class Contact : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.LinkText("Contact");
            }
        }

        /// <summary>The cookie question at the bottom of the window, until it is answered.</summary>
        public class ConsentBanner : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("consent-banner");

            public class Decline : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("button[data-consent='denied']");
            }
        }

        /// <summary>The green block at the top of the home page.</summary>
        public class Hero : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.CssSelector("section.hero");

            public class Title : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.TagName("h1");
            }
        }

        /// <summary>The band with the title at the top of every inner page.</summary>
        public class PageHeader : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.CssSelector("section.page-header");

            public class Title : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.TagName("h1");
            }
        }

        /// <summary>The contact form and the messages the server puts next to its fields.</summary>
        public class ContactForm : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.TagName("main");

            public class Send : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("button[type='submit']");
            }

            public class NameError : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("span[data-valmsg-for='Input.Name']");
            }

            public class EmailError : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("span[data-valmsg-for='Input.Email']");
            }

            public class MessageError : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("span[data-valmsg-for='Input.Message']");
            }
        }
    }
}
