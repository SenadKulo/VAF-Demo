using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    public class VAF_LandingPage : IPageContext
    {
        private string pageXpath = "//*[@id='dmRoot']";

        public By PageFindMechanism { get; set; }

        public VAF_LandingPage()
        {
            PageFindMechanism = By.XPath(pageXpath);
        }


        public class Home : ISectionContext
        {
            private const string elementXPath = "//div[contains(@class,'u_Home')]";

            public By SectionFindMechanism { get; set; }

            public Home()
            {
                SectionFindMechanism = By.XPath(elementXPath);
            }

            #region Nested Element objects

            /// <summary>
            /// DownloadNuget button
            /// </summary>
            public class DownloadNuget : IElementContext
            {
                private const string elementXPath = "//span[text()='DOWNLOAD NUGET']/..";
                public By ElementFindMechanism { get; set; }

                public DownloadNuget()
                {
                    ElementFindMechanism = By.XPath(elementXPath);
                }
            }

            #endregion
        }

        public class Features : ISectionContext
        {
            private const string elementXPath = "//div[contains(@class,'u_Features')]";

            public By SectionFindMechanism { get; set; }

            public Features()
            {
                SectionFindMechanism = By.XPath(elementXPath);
            }

            #region Nested Element objects

            /// <summary>
            /// QuickStartGuide link
            /// </summary>
            public class QuickStartGuide : IElementContext
            {
                private const string elementXPath = "//a[text()='quick start guide']";
                public By ElementFindMechanism { get; set; }

                public QuickStartGuide()
                {
                    ElementFindMechanism = By.XPath(elementXPath);
                }
            }

            #endregion
        }

        public class Testimonials : ISectionContext
        {
            private const string elementXPath = "//div[contains(@class,'u_Testimonials')]";

            public By SectionFindMechanism { get; set; }

            public Testimonials()
            {
                SectionFindMechanism = By.XPath(elementXPath);
            }

            #region Nested Element objects

            /// <summary>
            /// Title label
            /// </summary>
            public class Title : IElementContext
            {
                private const string elementXPath = "//span[text()='Testimonials']";
                public By ElementFindMechanism { get; set; }

                public Title()
                {
                    ElementFindMechanism = By.XPath(elementXPath);
                }
            }

            #endregion
        }

        public class ContactUs : ISectionContext
        {
            private const string elementXPath = "//div[contains(@class,'u_ContactUs')]";

            public By SectionFindMechanism { get; set; }

            public ContactUs()
            {
                SectionFindMechanism = By.XPath(elementXPath);
            }

            #region Nested Element objects

            /// <summary>
            /// Name text input
            /// </summary>
            internal class Name : IElementContext
            {
                private const string elementXPath = "//input[@name='dmform-0']";
                public By ElementFindMechanism { get; set; }

                public Name()
                {
                    ElementFindMechanism = By.XPath(elementXPath);
                }
            }

            /// <summary>
            /// Email text input
            /// </summary>
            internal class Email : IElementContext
            {
                private const string elementXPath = "//input[@name='dmform-1']";
                public By ElementFindMechanism { get; set; }

                public Email()
                {
                    ElementFindMechanism = By.XPath(elementXPath);
                }
            }

            /// <summary>
            /// Title label
            /// </summary>
            internal class Subject : IElementContext
            {
                private const string elementXPath = "//select[@name='dmform-3']";
                public By ElementFindMechanism { get; set; }

                public Subject()
                {
                    ElementFindMechanism = By.XPath(elementXPath);
                }
            }

            /// <summary>
            /// Message text input
            /// </summary>
            internal class Message : IElementContext
            {
                private const string elementXPath = "//input[@name='dmform-4']";
                public By ElementFindMechanism { get; set; }

                public Message()
                {
                    ElementFindMechanism = By.XPath(elementXPath);
                }
            }

            /// <summary>
            /// Send button
            /// </summary>
            internal class Send : IElementContext
            {
                private const string elementXPath = "//input[@value='SEND']";
                public By ElementFindMechanism { get; set; }

                public Send()
                {
                    ElementFindMechanism = By.XPath(elementXPath);
                }
            }

            /// <summary>
            /// ThankYouMessage label
            /// </summary>
            internal class ThankYouMessage : IElementContext
            {
                private const string elementXPath = "//div[@class='dmform-success']";
                public By ElementFindMechanism { get; set; }

                public ThankYouMessage()
                {
                    ElementFindMechanism = By.XPath(elementXPath);
                }
            }


            #endregion
        }

    }
}
