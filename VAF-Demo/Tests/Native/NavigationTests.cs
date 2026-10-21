using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.Tests.Native
{
    /// <summary>A drop-down menu and tabs: elements that are in the page but shown only after a click.</summary>
    [Category("Native")]
    public class NavigationTests : TestBase
    {
        [SetUp]
        public void Open() => SharedContext.LetsOpen("/practice/navigation");

        [Test]
        public void MenuItemIsChosen()
        {
            // A closed menu: the item is in the page, but not shown.
            SharedContext.App.Should().HaveSection<NavigationPage.AccountMenu>()
                .That.Should().NotHaveElement<NavigationPage.AccountMenu.Settings>();

            SharedContext.App.Should().HaveSection<NavigationPage.AccountMenu>()
                .That.Should().HaveElement<NavigationPage.AccountMenu.Open>()
                    .That.AsMenu().LetsClick()
                .AndAlso().Should().HaveElement<NavigationPage.AccountMenu.Settings>()
                    .That.AsMenu().LetsClick()
                .AndAlso().Should().HaveElement<NavigationPage.AccountMenu.Result>()
                    .That.AsLabelText().Should().HaveValue("Settings");
        }

        [Test]
        public void TabsSwitchThePane()
        {
            SharedContext.App.Should().HaveSection<NavigationPage.Tabs>()
                .That.Should().HaveElement<NavigationPage.Tabs.OverviewPane>()
                    .That.AsPane().Should().HaveValue("A small product to practise on.")
                .AndAlso().Should().HaveElement<NavigationPage.Tabs.Archive>()
                    .That.AsButton().Should().BeDisabled()
                .AndAlso().Should().HaveElement<NavigationPage.Tabs.Specifications>()
                    .That.AsButton().LetsClick()
                .AndAlso().Should().HaveElement<NavigationPage.Tabs.SpecificationsPane>()
                    .That.AsPane().Should().HaveValue("Weight 1 kg, width 20 cm.");

            SharedContext.App.Should().HaveSection<NavigationPage.Tabs>()
                .That.Should().NotHaveElement<NavigationPage.Tabs.OverviewPane>();
        }
    }
}
