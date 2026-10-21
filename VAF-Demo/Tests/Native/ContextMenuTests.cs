using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.Tests.Native
{
    /// <summary>A menu the page draws on right click (not the browser's own menu).</summary>
    [Category("Native")]
    public class ContextMenuTests : TestBase
    {
        [SetUp]
        public void Open() => SharedContext.LetsOpen("/practice/context-menu");

        [Test]
        public void PageMenuOpensOnRightClick()
        {
            SharedContext.App.Should().HaveSection<ContextMenuPage.PageMenu>()
                .That.Should().HaveElement<ContextMenuPage.PageMenu.Area>()
                    .That.LetsRightClick();

            SharedContext.App.Should().HaveSection<ContextMenuPage.PageMenu>()
                .That.Should().HaveElement<ContextMenuPage.PageMenu.Rename>()
                    .That.AsButton().LetsClick()
                .AndAlso().Should().HaveElement<ContextMenuPage.PageMenu.Result>()
                    .That.AsLabelText().Should().HaveValue("Rename");
        }
    }
}
