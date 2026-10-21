using System.Collections.Generic;
using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.Tests.Native
{
    [Category("Native")]
    public class TablesTests : TestBase
    {
        [SetUp]
        public void Open() => SharedContext.LetsOpen("/practice/tables");

        [Test]
        public void FilterNarrowsTheTable()
        {
            SharedContext.App.Should().HaveSection<TablesPage.Filter>()
                .That.Should().HaveElement<TablesPage.Filter.Text>()
                    .That.AsTextInputField().LetsInsert("Germany")
                .AndAlso().Should().HaveElement<TablesPage.Filter.Apply>()
                    .That.AsButton().LetsClick();

            SharedContext.App.Should().HaveSection<TablesPage.Summary>()
                .That.Should().HaveElement<TablesPage.Summary.MatchCount>()
                    .That.AsCounterField().Should().HaveValue("4");

            SharedContext.App.Should().HaveSection<TablesPage.People>()
                .That.Should().HaveElement<TablesPage.People.Body>()
                    .That.AsTableBody().Should().HaveNumberOfRows(4);

            // A value can also be read out of the page and checked with NUnit.
            List<string> names = SharedContext.App.Should().HaveSection<TablesPage.People>()
                .That.LetsGetTextValuesOfElements<TablesPage.People.Name>();

            Assert.That(names, Is.EqualTo(new List<string>
            {
                "Felix Schneider", "Jonas Weber", "Lena Fischer", "Sophie Wagner"
            }));
        }

        [Test]
        public void SortingByJoinedPutsTheOldestFirst()
        {
            SharedContext.App.Should().HaveSection<TablesPage.People>()
                .That.Should().HaveElement<TablesPage.People.SortByJoined>()
                    .That.AsLink().LetsClick();

            SharedContext.App.Should().HaveSection<TablesPage.People>()
                .That.Should().HaveElement<TablesPage.People.FirstJoined>()
                    .That.AsLabelText().Should().HaveValue("2011")
                .AndAlso().Should().HaveElement<TablesPage.People.FirstName>()
                    .That.AsLabelText().Should().HaveValue("Daniel Green");
        }
    }
}
