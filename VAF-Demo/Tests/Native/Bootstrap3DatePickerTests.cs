using System;
using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.Tests.Native
{
    /// <summary>Bootstrap 3 datetimepicker 4, on a page with its own Bootstrap 3 layout.</summary>
    [Category("Native")]
    public class Bootstrap3DatePickerTests : TestBase
    {
        [SetUp]
        public void Open() => SharedContext.LetsOpen("/practice/date-pickers-bootstrap3");

        [Test]
        public void DateIsChosenAndRead()
        {
            var date = new DateTime(2026, 10, 5);

            SharedContext.App.Should().HaveSection<Bootstrap3DatePickerPage.Start>()
                .That.Should().HaveElement<Bootstrap3DatePickerPage.Start.Picker>()
                    .That.AsDateTimeBootstrap3DatepickerV4().LetsSelectDate(date)
                .AndAlso().Should().HaveElement<Bootstrap3DatePickerPage.Start.Selected>()
                    .That.AsLabelText().Should().HaveValue("10/05/2026");
        }
    }
}
