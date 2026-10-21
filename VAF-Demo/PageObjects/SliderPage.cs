using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary><see href="https://www.visionautomationframework.com/practice/slider">/practice/slider</see>: a range 0–100 and the number it shows.</summary>
    public static class SliderPage
    {
        public class Volume : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("volume-demo");

            public class Slider : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("volume");
            }

            public class Value : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("volume-value");
            }
        }
    }
}
