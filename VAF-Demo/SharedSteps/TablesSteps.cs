using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.SharedSteps
{
    /// <summary>Steps for /practice/tables.</summary>
    public static class TablesSteps
    {
        public static void LetsOpenTheTable() => SharedContext.LetsOpen("/practice/tables");

        public static void LetsFilter(string text)
        {
            SharedContext.App.Should().HaveSection<TablesPage.Filter>()
                .That.Should().HaveElement<TablesPage.Filter.Text>()
                    .That.AsTextInputField().LetsInsert(text)
                .AndAlso().Should().HaveElement<TablesPage.Filter.Apply>()
                    .That.AsButton().LetsClick();
        }

        public static void LetsSortByJoined()
        {
            SharedContext.App.Should().HaveSection<TablesPage.People>()
                .That.Should().HaveElement<TablesPage.People.SortByJoined>()
                    .That.AsLink().LetsClick();
        }

        /// <summary>The counter above the table and the rows in it (all fit on one page, up to 10).</summary>
        public static void LetsCheckTheNumberOfPeople(int count)
        {
            SharedContext.App.Should().HaveSection<TablesPage.Summary>()
                .That.Should().HaveElement<TablesPage.Summary.MatchCount>()
                    .That.AsCounterField().Should().HaveValue(count.ToString());

            SharedContext.App.Should().HaveSection<TablesPage.People>()
                .That.Should().HaveElement<TablesPage.People.Body>()
                    .That.AsTableBody().Should().HaveNumberOfRows(count);
        }

        public static void LetsCheckTheFirstPerson(string name)
        {
            SharedContext.App.Should().HaveSection<TablesPage.People>()
                .That.Should().HaveElement<TablesPage.People.FirstName>()
                    .That.AsLabelText().Should().HaveValue(name);
        }

        public static void LetsCheckTheFirstYear(string year)
        {
            SharedContext.App.Should().HaveSection<TablesPage.People>()
                .That.Should().HaveElement<TablesPage.People.FirstJoined>()
                    .That.AsLabelText().Should().HaveValue(year);
        }
    }
}
