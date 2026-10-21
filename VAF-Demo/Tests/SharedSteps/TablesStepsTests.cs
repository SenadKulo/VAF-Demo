using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.SharedSteps;

namespace VAF_Demo.Tests.SharedSteps
{
    [Category("SharedSteps")]
    public class TablesStepsTests : TestBase
    {
        [SetUp]
        public void Open() => TablesSteps.LetsOpenTheTable();

        /// <summary>One test, several cases: the filter looks in the name, the country and the role, in any case.</summary>
        [TestCase("Germany", 4, "Felix Schneider")]
        [TestCase("Montenegro", 3, "Ana Radović")]
        [TestCase("Team lead", 5, "Daniel Green")]
        [TestCase("bosnia", 4, "Amina Hodžić")]
        public void FilterNarrowsTheTable(string filter, int people, string first)
        {
            TablesSteps.LetsFilter(filter);
            TablesSteps.LetsCheckTheNumberOfPeople(people);
            TablesSteps.LetsCheckTheFirstPerson(first);
        }

        [Test]
        public void SortingByJoinedPutsTheOldestFirst()
        {
            TablesSteps.LetsSortByJoined();
            TablesSteps.LetsCheckTheFirstYear("2011");
            TablesSteps.LetsCheckTheFirstPerson("Daniel Green");
        }
    }
}
