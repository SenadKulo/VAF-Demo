using System;
using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.Tests.Native
{
    /// <summary>flatpickr 4: VAF opens the calendar and clicks through to the date.</summary>
    [Category("Native")]
    public class DatePickersTests : TestBase
    {
        [SetUp]
        public void Open() => SharedContext.LetsOpen("/practice/date-pickers");

        [Test]
        public void DateIsChosenAndRead()
        {
            var date = new DateTime(2026, 10, 5);

            SharedContext.App.Should().HaveSection<DatePickersPage.Single>()
                .That.Should().HaveElement<DatePickersPage.Single.Birthday>()
                    .That.AsDateTimeFlatpickerV4().LetsSelectDate(date)
                .AndAlso().Should().HaveElement<DatePickersPage.Single.Birthday>()
                    .That.AsDateTimeFlatpickerV4().Should().HaveValue(date, "yyyy-MM-dd")
                .AndAlso().Should().HaveElement<DatePickersPage.Single.Selected>()
                    .That.AsLabelText().Should().HaveValue("2026-10-05");
        }

        [Test]
        public void FromAndToInDifferentYears()
        {
            var from = new DateTime(2018, 3, 15);
            var to = new DateTime(2028, 11, 20);

            SharedContext.App.Should().HaveSection<DatePickersPage.Range>()
                .That.Should().HaveElement<DatePickersPage.Range.From>()
                    .That.AsDateTimeFlatpickerV4().LetsSelectDate(from)
                .AndAlso().Should().HaveElement<DatePickersPage.Range.To>()
                    .That.AsDateTimeFlatpickerV4().LetsSelectDate(to)
                .AndAlso().Should().HaveElement<DatePickersPage.Range.From>()
                    .That.AsDateTimeFlatpickerV4().Should().HaveValue(from, "yyyy-MM-dd")
                .AndAlso().Should().HaveElement<DatePickersPage.Range.To>()
                    .That.AsDateTimeFlatpickerV4().Should().HaveValue(to, "yyyy-MM-dd")
                .AndAlso().Should().HaveElement<DatePickersPage.Range.Days>()
                    .That.AsLabelText().Should().HaveValue(((int)(to - from).TotalDays).ToString());
        }
    }
}
