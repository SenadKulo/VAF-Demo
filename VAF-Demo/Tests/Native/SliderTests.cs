using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.Tests.Native
{
    [Category("Native")]
    public class SliderTests : TestBase
    {
        [SetUp]
        public void Open() => SharedContext.LetsOpen("/practice/slider");

        [Test]
        public void ExactValueIsSet()
        {
            SharedContext.App.Should().HaveSection<SliderPage.Volume>()
                .That.Should().HaveElement<SliderPage.Volume.Slider>()
                    .That.AsSlideBar().Should().HaveValue("50");

            // LetsSetValue ends the chain, so the check starts a new one.
            SharedContext.App.Should().HaveSection<SliderPage.Volume>()
                .That.Should().HaveElement<SliderPage.Volume.Slider>()
                    .That.AsSlideBar().LetsSetValue(73);

            SharedContext.App.Should().HaveSection<SliderPage.Volume>()
                .That.Should().HaveElement<SliderPage.Volume.Slider>()
                    .That.AsSlideBar().Should().HaveValue("73")
                .AndAlso().Should().HaveElement<SliderPage.Volume.Value>()
                    .That.AsLabelText().Should().HaveValue("73");
        }
    }
}
