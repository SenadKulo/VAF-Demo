using System;
using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.SharedSteps
{
    /// <summary>Steps for /practice/date-pickers (flatpickr).</summary>
    public static class DatePickersSteps
    {
        public static void LetsOpenTheDatePickers() => SharedContext.LetsOpen("/practice/date-pickers");

        public static void LetsChooseTheBirthday(DateTime date)
        {
            SharedContext.App.Should().HaveSection<DatePickersPage.Single>()
                .That.Should().HaveElement<DatePickersPage.Single.Birthday>()
                    .That.AsDateTimeFlatpickerV4().LetsSelectDate(date);
        }

        public static void LetsCheckTheBirthday(DateTime date)
        {
            SharedContext.App.Should().HaveSection<DatePickersPage.Single>()
                .That.Should().HaveElement<DatePickersPage.Single.Birthday>()
                    .That.AsDateTimeFlatpickerV4().Should().HaveValue(date, "yyyy-MM-dd")
                .AndAlso().Should().HaveElement<DatePickersPage.Single.Selected>()
                    .That.AsLabelText().Should().HaveValue(date.ToString("yyyy-MM-dd"));
        }

        public static void LetsChooseTheDates(DateTime from, DateTime to)
        {
            SharedContext.App.Should().HaveSection<DatePickersPage.Range>()
                .That.Should().HaveElement<DatePickersPage.Range.From>()
                    .That.AsDateTimeFlatpickerV4().LetsSelectDate(from)
                .AndAlso().Should().HaveElement<DatePickersPage.Range.To>()
                    .That.AsDateTimeFlatpickerV4().LetsSelectDate(to);
        }

        /// <summary>Both dates, and the number of days between them that the page works out.</summary>
        public static void LetsCheckTheDates(DateTime from, DateTime to)
        {
            SharedContext.App.Should().HaveSection<DatePickersPage.Range>()
                .That.Should().HaveElement<DatePickersPage.Range.From>()
                    .That.AsDateTimeFlatpickerV4().Should().HaveValue(from, "yyyy-MM-dd")
                .AndAlso().Should().HaveElement<DatePickersPage.Range.To>()
                    .That.AsDateTimeFlatpickerV4().Should().HaveValue(to, "yyyy-MM-dd")
                .AndAlso().Should().HaveElement<DatePickersPage.Range.Days>()
                    .That.AsLabelText().Should().HaveValue(((int)(to - from).TotalDays).ToString());
        }
    }
}
