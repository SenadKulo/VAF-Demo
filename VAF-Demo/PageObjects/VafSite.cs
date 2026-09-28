using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary>
    /// Layer 1 — page objects: the app, its sections and their elements. The whole site is one page context; every part of it (menu, page header,
    /// contact form, …) is a section with its elements nested inside. An element's locator is
    /// looked up inside its section, so it can stay short.
    /// </summary>
    public class VafSite : IPageContext
    {
        public By PageFindMechanism { get; set; } = By.TagName("body");

        /// <summary>The green menu bar at the top of every page.</summary>
        public class Navigation : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.CssSelector("nav.site-nav");

            public class QuickStart : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.LinkText("Quick start");
            }

            public class Guide : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.LinkText("Guide");
            }

            public class Contact : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.LinkText("Contact");
            }
        }

        /// <summary>The sand band with the title at the top of every inner page.</summary>
        public class PageHeader : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.CssSelector("section.page-header");

            public class Title : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.TagName("h1");
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

        /// <summary>"Why VAF" on the home page.</summary>
        public class Features : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("features");

            public class Title : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("h2.section-title");
            }
        }

        /// <summary>The numbered steps and the notes of the Quick start guide.</summary>
        public class QuickStartSteps : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.TagName("main");

            public class FirstStep : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("h2.h4");
            }

            public class BetaLink : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector(".alert-info a[href='/migrating-to-3']");
            }
        }

        /// <summary>The chapter list at the side of the Guide (shown on wide screens).</summary>
        public class GuideContents : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.CssSelector("nav[aria-label='Guide contents']");

            public class Tests : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("a[href='#tests']");
            }
        }

        /// <summary>The contact page: the form and the messages it shows after sending.</summary>
        public class ContactForm : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.TagName("main");

            public class Name : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("Input_Name");
            }

            public class Email : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("Input_Email");
            }

            public class Topic : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("Input_Topic");
            }

            public class Message : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("Input_Message");
            }

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

            public class SentConfirmation : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector(".alert-success");
            }
        }
    }
}
