using System;
using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.SharedSteps;

namespace VAF_Demo.Tests.Scenarios
{
    /// <summary>
    /// Level 3 — scenarios: longer flows across several pages, written only with shared steps.
    /// The practice pages do not share any data, so these show the shape of a scenario, not a real
    /// end-to-end test (where, say, an order placed on one page shows up on another).
    /// </summary>
    [Category("Scenarios")]
    public class ScenarioTests : TestBase
    {
        [Test]
        public void NewcomerFindsAPageAndPractises()
        {
            PracticeSteps.LetsOpenTheOverview();

            PracticeSteps.LetsGoToForms();
            PracticeSteps.LetsCheckThePageTitle("Forms");
            FormsSteps.LetsRegister("Grace Hopper", "grace@example.com", "compiler1", "United States", plan: "Free");
            FormsSteps.LetsCheckTheResult("Grace Hopper", "grace@example.com", "United States", plan: "Free");

            PracticeSteps.LetsGoBackToTheOverview();
            PracticeSteps.LetsGoToTables();
            TablesSteps.LetsFilter("Tester");
            TablesSteps.LetsCheckTheNumberOfPeople(8);
        }

        [Test]
        public void TripIsPlanned()
        {
            var from = new DateTime(2027, 5, 3);
            var to = new DateTime(2027, 5, 17);

            PracticeSteps.LetsOpenTheOverview();

            PracticeSteps.LetsGoToDatePickers();
            DatePickersSteps.LetsChooseTheDates(from, to);
            DatePickersSteps.LetsCheckTheDates(from, to);

            PracticeSteps.LetsGoBackToTheOverview();
            PracticeSteps.LetsGoToTables();
            TablesSteps.LetsFilter("United Kingdom");
            TablesSteps.LetsCheckTheNumberOfPeople(3);
            TablesSteps.LetsCheckTheFirstPerson("Grace Taylor");

            PracticeSteps.LetsGoBackToTheOverview();
            PracticeSteps.LetsGoToWindows();
            WindowsSteps.LetsOpenTheChildInANewTab();
            WindowsSteps.LetsCheckTheChildWasOpenedBy("link");
            WindowsSteps.LetsCloseTheChild();
        }
    }
}
