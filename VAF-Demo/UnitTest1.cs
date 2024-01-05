using NUnit.Framework;
using VisionAutomationFramework;
using VisionAutomationFramework.Browsers;

namespace VAF_Demo
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Testing.On<Chrome>().LetsNavigateTo("https://www.visionautomationframework.com/");
        }
    }
}