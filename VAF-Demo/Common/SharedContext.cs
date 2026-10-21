using System;
using VAF_Demo.PageObjects;
using VisionAutomationFramework;
using VisionAutomationFramework.Actions;
using VisionAutomationFramework.Browsers;
using VisionAutomationFramework.Extensions;

namespace VAF_Demo.Common
{
    /// <summary>
    /// The state of the test session, shared by the tests of every level and by the shared steps:
    /// the browser, the page context of the application, and the address of the site under test.
    ///
    /// How it is used:
    /// - TestBase starts the browser before each test (LetsStartTheBrowser) and closes it after
    ///   (LetsCloseTheBrowser).
    /// - The test, in its [SetUp] or through a step such as FormsSteps.LetsOpenTheForm, goes to its
    ///   page with LetsOpen, which fills <see cref="App"/>.
    /// - Every chain after that starts from <see cref="App"/>:
    ///   SharedContext.App.Should().HaveSection&lt;FormsPage.Registration&gt;()…
    ///   App stays valid when a click leads to another page: VAF looks for the section in whatever
    ///   page the browser shows at that moment, so there is nothing to fill again after navigation.
    ///
    /// The properties are static, so the tests run one after another, not in parallel. VAF keeps its
    /// browser in a static field too, so this costs nothing extra.
    /// </summary>
    public static class SharedContext
    {
        /// <summary>
        /// The site under test. Set VAF_DEMO_BASE_URL to run against another copy, e.g. a local one
        /// (http://localhost:5238).
        /// </summary>
        public static string BaseUrl { get; } =
            (Environment.GetEnvironmentVariable("VAF_DEMO_BASE_URL") ?? "https://www.visionautomationframework.com").TrimEnd('/');

        /// <summary>The browser: windows, tabs, dialogs and the page title.</summary>
        public static BrowserActions Browser { get; private set; }

        /// <summary>The page context of the whole application; every section is found from here.</summary>
        public static PageActions<AppPage> App { get; private set; }

        /// <summary>Starts Chrome, still without a page. Called by TestBase before each test.</summary>
        public static void LetsStartTheBrowser()
        {
            Browser = Testing.On<Chrome>();
        }

        /// <summary>Goes to a page of the site (e.g. "/practice/forms") and fills <see cref="App"/>.</summary>
        public static void LetsOpen(string path)
        {
            App = Browser.LetsNavigateTo(BaseUrl + path)
                .Should().DisplayPage<AppPage>().That;
        }

        /// <summary>Closes the browser and clears the state. Called by TestBase after each test.</summary>
        public static void LetsCloseTheBrowser()
        {
            Browser?.Scope.Driver.Quit();
            Browser = null;
            App = null;
        }
    }
}
