using NUnit.Framework;
using System;
using VAF_Demo.PageObjects;
using VisionAutomationFramework;
using VisionAutomationFramework.Actions;
using VisionAutomationFramework.Browsers;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo
{
    public class DemoTests
    {
        // Placeholder testing property that is used inside test methods 
        PageActions TestingContext { get; set; }

        /// <summary>
        /// Setup method, runs before each test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            TestingContext = Testing.On<Chrome>().LetsNavigateTo("https://www.visionautomationframework.com/")
                .Should().DisplayPage<VAF_LandingPage>().That;
        }


        /// <summary>
        /// Cleanup method, runs after each test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            TestingContext.Browser.Scope.Driver.Quit();
        }

        /// <summary>
        /// Open VAF site and click on Download Nuget button inside Home section
        /// </summary>
        [Test]
        public void Test1()
        {
            TestingContext.Should().HaveSection<VAF_LandingPage.Home>()
                .That.Should().HaveElement<VAF_LandingPage.Home.DownloadNuget>()
                    .That.AsButton().LetsClick();
        }

        /// <summary>
        /// Open VAF site and click on quick start guide link inside Features section
        /// </summary>
        [Test]
        public void Test2()
        {
            TestingContext.Should().HaveSection<VAF_LandingPage.Features>()
                .That.Should().HaveElement<VAF_LandingPage.Features.QuickStartGuide>()
                    .That.AsLink().LetsClick();
        }

        /// <summary>
        /// Open VAF site and click on quick start guide link inside Features section
        /// </summary>
        [Test]
        public void Test3()
        {
            TestingContext.Should().HaveSection<VAF_LandingPage.Testimonials>()
                .That.Should().HaveElement<VAF_LandingPage.Testimonials.Title>()
                    .That.AsLabelText().Should().HaveValue("Testimonials");
        }

        /// <summary>
        /// Open VAF site and click on quick start guide link inside Features section
        /// </summary>
        [Test]
        public void Test4()
        {
            TestingContext.Should().HaveSection<VAF_LandingPage.ContactUs>()
                .That.Should().HaveElement<VAF_LandingPage.ContactUs.Name>()
                    .That.AsTextInputField().LetsInsert("Automation Name")
                .AndAlso().Should().HaveElement<VAF_LandingPage.ContactUs.Email>()
                    .That.AsTextInputField().LetsInsert("automation@email.com")
                .AndAlso().Should().HaveElement<VAF_LandingPage.ContactUs.Subject>()
                    .That.AsSelectBox().LetsSelect("Other")
                .AndAlso().Should().HaveElement<VAF_LandingPage.ContactUs.Message>()
                    .That.AsTextInputField().LetsInsert("Message from Automation " + DateTime.Now.ToString("MM-dd-yyyy"))
                .AndAlso().Should().HaveElement<VAF_LandingPage.ContactUs.Send>()
                    .That.AsButton().LetsClick();

            TestingContext.Should().HaveSection<VAF_LandingPage.ContactUs>()
                .That.Should().HaveElement<VAF_LandingPage.ContactUs.ThankYouMessage>()
                    .That.AsLabelText().Should().Contain("Thank you for contacting us.");
        }
    }
}