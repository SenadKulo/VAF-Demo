using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary>/practice/upload: the server shows the name and size of what it received, and keeps nothing.</summary>
    public static class UploadPage
    {
        public class Form : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("upload-form");

            public class Single : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("single-file");
            }

            public class Upload : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("upload-button");
            }
        }

        public class Result : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("upload-result");

            public class Count : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("received-count");
            }

            public class First : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("received-1");
            }
        }
    }
}
