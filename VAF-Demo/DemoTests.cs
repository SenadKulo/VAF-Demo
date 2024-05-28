using NUnit.Framework;
using System;
using VAF_Demo.PageObjects;
using VisionAutomationFramework;
using VisionAutomationFramework.Actions;
using VisionAutomationFramework.Browsers;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo
{
    /// <summary>
    /// DemoTests class provides examples of how to use the Vision Automation Framework (VAF)
    /// to write automated UI tests. It includes basic interactions, assertions, and multi-step actions.
    /// </summary>		 
    public class DemoTests
    {
        // Placeholder property used inside test methods 
        // Holds PageAction scope based on which code will perform further actions and assertions
        PageActions TestingContext { get; set; }

        /// <summary>
        /// Setup method, runs before each test.
        /// Initializes the Chrome driver and navigates to the website before starting individual tests. 
        /// Also, it sets up the TestingContext property with the current page.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            TestingContext = Testing.On<Chrome>().LetsNavigateTo("https://www.visionautomationframework.com/")
                .Should().DisplayPage<VAF_LandingPage>().That;
        }

        /// <summary>
        /// Cleanup method, runs after each test.
        /// Ensures that the driver is closed after each individual test method, regardless of the test's outcome.
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            TestingContext.Browser.Scope.Driver.Quit();
        }

        /// <summary>
        /// Opens the VAF site and clicks on the "Download Nuget" button in the Home section.
        /// 
        /// This basic method demonstrates how to navigate to a specific section and perform a basic action, such as clicking a button element.
        /// </summary>
        [Test]
        public void Test1()
        {
            TestingContext.Should().HaveSection<VAF_LandingPage.Home>()
                .That.Should().HaveElement<VAF_LandingPage.Home.DownloadNuget>()
                    .That.AsButton().LetsClick();
        }

        /// <summary>
        /// Opens the VAF site and clicks on the "Quick Start Guide" link in the Features section.
        /// 
        /// This method shows the user's ability to interact with different types of elements and perform actions on them.
        /// </summary>
        [Test]
        public void Test2()
        {
            TestingContext.Should().HaveSection<VAF_LandingPage.Features>()
                .That.Should().HaveElement<VAF_LandingPage.Features.QuickStartGuide>()
                    .That.AsLink().LetsClick();
        }

        /// <summary>
        /// Opens the VAF site and verifies the "Testimonials" title in the Testimonials section.
        /// 
        /// This test demonstrates how to use assertions. By using the Should() method, you can verify that a label has a specific text value.
        /// </summary>
        [Test]
        public void Test3()
        {
            TestingContext.Should().HaveSection<VAF_LandingPage.Testimonials>()
                .That.Should().HaveElement<VAF_LandingPage.Testimonials.Title>()
                    .That.AsLabelText().Should().HaveValue("Testimonials");
        }

        /// <summary>
        /// Completes the Contact Us form and verifies the "Thank You" message.
        /// 
        /// This "complex" test method uses the TestingContext property in multiple steps to interact with various elements.
        /// It introduces the AndAlso() method, which allows you to continue with assertions and actions on different elements within the same context.
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
