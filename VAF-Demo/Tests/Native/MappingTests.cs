using System.Collections.Generic;
using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.Tests.Native
{
    /// <summary>
    /// Good and bad locators: the same order summary, mapped with stable locators (MappingPage) and
    /// with fragile ones (MappingPageFragile), before and after a redesign (?version=2).
    /// </summary>
    [Category("Native")]
    public class MappingTests : TestBase
    {
        /// <summary>The same test passes before and after the redesign: ids and data-test did not change.</summary>
        [TestCase("/practice/mapping")]
        [TestCase("/practice/mapping?version=2")]
        public void StableLocatorsSurviveTheRedesign(string path)
        {
            SharedContext.LetsOpen(path);

            SharedContext.App.Should().HaveSection<MappingPage.Order>()
                .That.Should().HaveElement<MappingPage.Order.Total>()
                    .That.AsLabelText().Should().HaveValue("€39.50")
                .AndAlso().Should().HaveElement<MappingPage.Order.Note>()
                    .That.AsTextInputField().LetsInsert("Ring twice")
                .AndAlso().Should().HaveElement<MappingPage.Order.SaveNote>()
                    .That.AsButton().LetsClick()
                .AndAlso().Should().HaveElement<MappingPage.Order.Message>()
                    .That.AsLabelText().Should().HaveValue("Note saved: Ring twice")
                .AndAlso().Should().HaveElement<MappingPage.Order.Cancel>()
                    .That.AsButton().LetsClick()
                .AndAlso().Should().HaveElement<MappingPage.Order.Status>()
                    .That.AsLabelText().Should().HaveValue("Cancelled");

            // Version 2 lists the items in another order, so the test checks them without an order.
            List<string> items = SharedContext.App.Should().HaveSection<MappingPage.Order>()
                .That.LetsGetTextValuesOfElements<MappingPage.Order.ItemName>();

            Assert.That(items, Is.EquivalentTo(new[] { "Coffee beans, 1 kg", "Ceramic mug", "Paper filters" }));
        }

        /// <summary>
        /// Passes — on version 1 only. Change the path to "/practice/mapping?version=2" and run it again:
        /// every check fails, each for the reason written on its locator in MappingPageFragile.
        /// </summary>
        [Test]
        public void FragileLocatorsWorkUntilTheRedesign()
        {
            SharedContext.LetsOpen("/practice/mapping");

            SharedContext.App.Should().HaveElement<MappingPageFragile.Title>()
                .That.AsLabelText().Should().HaveValue("Order #1042");
            SharedContext.App.Should().HaveElement<MappingPageFragile.Status>()
                .That.AsLabelText().Should().HaveValue("Paid");
            SharedContext.App.Should().HaveElement<MappingPageFragile.ThirdItemName>()
                .That.AsLabelText().Should().HaveValue("Paper filters");
            SharedContext.App.Should().HaveElement<MappingPageFragile.Total>()
                .That.AsLabelText().Should().HaveValue("€39.50");
        }
    }
}
