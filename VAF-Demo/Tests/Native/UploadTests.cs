using System.IO;
using NUnit.Framework;
using VAF_Demo.Common;
using VAF_Demo.PageObjects;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.Tests.Native
{
    [Category("Native")]
    public class UploadTests : TestBase
    {
        [SetUp]
        public void Open() => SharedContext.LetsOpen("/practice/upload");

        [Test]
        public void OneFileIsReceived()
        {
            // A small file with a known size, in the test's own folder.
            string file = Path.Combine(TestContext.CurrentContext.WorkDirectory, "vaf-demo-upload.txt");
            File.WriteAllText(file, "Hello VAF");

            SharedContext.App.Should().HaveSection<UploadPage.Form>()
                .That.Should().HaveElement<UploadPage.Form.Single>()
                    .That.AsUploadFileField().LetsUpload(file)
                .AndAlso().Should().HaveElement<UploadPage.Form.Upload>()
                    .That.AsButton().LetsClick();

            // Sending the form loads the page again; App finds the result in the new page.
            SharedContext.App.Should().HaveSection<UploadPage.Result>()
                .That.Should().HaveElement<UploadPage.Result.Count>()
                    .That.AsCounterField().Should().HaveValue("1")
                .AndAlso().Should().HaveElement<UploadPage.Result.First>()
                    .That.AsLabelText().Should().HaveValue("vaf-demo-upload.txt — 9 bytes");
        }
    }
}
