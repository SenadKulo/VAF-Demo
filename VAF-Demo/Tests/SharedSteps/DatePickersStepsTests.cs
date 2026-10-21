using System;
using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.SharedSteps;

namespace VAF_Demo.Tests.SharedSteps
{
    [Category("SharedSteps")]
    public class DatePickersStepsTests : TestBase
    {
        [SetUp]
        public void Open() => DatePickersSteps.LetsOpenTheDatePickers();

        [Test]
        public void DateIsChosenAndRead()
        {
            var date = new DateTime(2026, 10, 5);

            DatePickersSteps.LetsChooseTheBirthday(date);
            DatePickersSteps.LetsCheckTheBirthday(date);
        }

        [Test]
        public void FromAndToInDifferentYears()
        {
            var from = new DateTime(2018, 3, 15);
            var to = new DateTime(2028, 11, 20);

            DatePickersSteps.LetsChooseTheDates(from, to);
            DatePickersSteps.LetsCheckTheDates(from, to);
        }
    }
}
