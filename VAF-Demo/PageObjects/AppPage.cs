using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary>
    /// The one page context of the whole application: the root every section is found in.
    /// VAF looks for a section in whatever page the browser shows at that moment, so one page context
    /// is enough for every screen. The screens themselves are the other classes in this folder, one
    /// file each, and each holds the sections of that screen.
    /// </summary>
    public class AppPage : IPageContext
    {
        public By PageFindMechanism { get; set; } = By.TagName("body");
    }
}
