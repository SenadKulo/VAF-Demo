# Vision Automation Framework — demo

[![Tests](https://github.com/SenadKulo/VAF-Demo/actions/workflows/tests.yml/badge.svg)](https://github.com/SenadKulo/VAF-Demo/actions/workflows/tests.yml)

Browser tests written with [Vision Automation Framework](https://www.nuget.org/packages/VisionAutomationFramework)
(VAF) **3.3**, against the [practice pages](https://www.visionautomationframework.com/practice) — pages made
for test automation, with stable ids, that do not change under the tests. The same tests are written three
ways, so you can see how a VAF suite grows from single tests into something you can maintain:

| Level | Folder | What a test looks like |
|---|---|---|
| 1 — native | [`Tests/Native`](VAF-Demo/Tests/Native) | The whole VAF chain in the test: app → section → element → action or check |
| 2 — shared steps | [`SharedSteps`](VAF-Demo/SharedSteps), [`Tests/SharedSteps`](VAF-Demo/Tests/SharedSteps) | 3–5 lines that read as what the user does; the chains live in steps |
| 3 — scenarios | [`Tests/Scenarios`](VAF-Demo/Tests/Scenarios) | Longer flows across several pages, only through steps |

All three use the same [page objects](VAF-Demo/PageObjects) and the same session state in [`Common`](VAF-Demo/Common). [`Tests/Site`](VAF-Demo/Tests/Site) has two tests
against the site's own pages, which were not made for testing.

## Run

Requirements: the [.NET 10 SDK](https://dotnet.microsoft.com/download) and Google Chrome. Selenium
downloads the matching ChromeDriver on the first run.

```
dotnet test
```

or **Test → Run All Tests** in Visual Studio 2026. One level only:

```
dotnet test --filter TestCategory=Native
dotnet test --filter TestCategory=SharedSteps
dotnet test --filter TestCategory=Scenarios
dotnet test --filter TestCategory=Site
```

A run of all 36 tests takes about four minutes: every test opens its own Chrome. The tests run one after
another, not in parallel: they share the session state in [`SharedContext`](VAF-Demo/Common/SharedContext.cs).

The project is what Visual Studio's *NUnit Test Project* template creates (.NET 10, NUnit 4) plus the VAF
package. For .NET Framework, set `<TargetFramework>net472</TargetFramework>`.

### Settings

| Environment variable | Default | Meaning |
|---|---|---|
| `VAF_DEMO_BASE_URL` | `https://www.visionautomationframework.com` | The site under test |
| `VAF_ChromeArguments` | — | Extra Chrome arguments, e.g. `--headless=new --window-size=1920,1080` to run without a window |
| `VAF_ElementWaitTimeout` | 10 | Seconds VAF waits for an element |

In PowerShell: `$env:VAF_ChromeArguments = "--headless=new --window-size=1920,1080"; dotnet test`.

Give headless Chrome a window size: without one its window is about 800 px wide, and below 992 px the
site folds its menu behind a button, so the tests in `Tests/Site` do not find the menu links.

## Page objects

The application is mapped once ([`PageObjects`](VAF-Demo/PageObjects)), in three levels, as in the
[Guide](https://www.visionautomationframework.com/guide#sections):

- **The app** — [`AppPage`](VAF-Demo/PageObjects/AppPage.cs), the one `IPageContext` of the whole application
  (`body`). VAF looks for a section in whatever page the browser shows, so one page context is enough.
- **Sections** — each screen gets its own file with the sections on it (`FormsPage.Registration`,
  `FormsPage.Result`, …). `FormsPage` itself only groups them.
- **Elements** — nested in their section, so `FormsPage.Registration.FullName` says exactly where the field is.

Each class holds only a locator:

```csharp
public static class FormsPage
{
    public class Registration : ISectionContext
    {
        public By SectionFindMechanism { get; set; } = By.Id("registration");

        public class FullName : IElementContext
        {
            public By ElementFindMechanism { get; set; } = By.Id("full-name");
        }
    }
}
```

An element is looked up inside its section, so its locator can stay short. The practice pages give every
element an `id`, which survives changes to the layout and the text. `PracticeLayout` holds the sections every
practice page has (breadcrumb, page header).

### Good and bad locators

[Good and bad locators](https://www.visionautomationframework.com/practice/mapping) shows the same order summary
twice: built for testing (`id`, `data-test`) and built without it (generated classes, nested `div`s, text only,
an `id` that changes on every load). `?version=2` shows the same screen after a redesign.

- [`MappingPage`](VAF-Demo/PageObjects/MappingPage.cs) maps the first one; `StableLocatorsSurviveTheRedesign` in
  [`MappingTests`](VAF-Demo/Tests/Native/MappingTests.cs) passes on both versions.
- [`MappingPageFragile`](VAF-Demo/PageObjects/MappingPageFragile.cs) maps the second one the way not to, with the
  reason on every locator. `FragileLocatorsWorkUntilTheRedesign` passes on version 1; change its path to
  `/practice/mapping?version=2` and run it to see each locator break.

Prefer, from the most to the least stable: `id` and `data-test` → `name`, `label`, ARIA → CSS class → text →
position and absolute XPath → generated ids and classes. When a page offers only the last ones, ask its
developers for an `id` or a `data-test`.

## Common: test base and shared context

Two classes in [`Common`](VAF-Demo/Common) hold what every test needs:

- [`TestBase`](VAF-Demo/Common/TestBase.cs) — the base of every test class and the life of the browser in one
  place: `[SetUp]` starts Chrome before each test, `[TearDown]` reports and closes it after.
- [`SharedContext`](VAF-Demo/Common/SharedContext.cs) — the state of the test session: the browser, the page
  context of the application (`App`) and the address of the site.

A test class adds only its own `[SetUp]`: `SharedContext.LetsOpen("/practice/forms")` goes to its page and fills
`App`. Every chain after that, in a test or in a step, starts from `SharedContext.App`. `App` stays valid when a
click leads to another page, so it is filled once per test.

## Level 1 — native

[`Tests/Native`](VAF-Demo/Tests/Native): one or two tests for each practice page. The test spells out the chain:

```csharp
[SetUp]
public void Open() => SharedContext.LetsOpen("/practice/forms");   // TestBase started Chrome; go to the page, fill App

[Test]
public void ValidRegistrationIsShownBack()
{
    SharedContext.App.Should().HaveSection<FormsPage.Registration>()   // find the section (VAF waits for it)
        .That.Should().HaveElement<FormsPage.Registration.FullName>()  // find the element in it
            .That.AsTextInputField().LetsInsert("Ada Lovelace")       // say what it is, then act
        .AndAlso().Should().HaveElement<FormsPage.Registration.Email>()  // next element, same section
            .That.AsTextInputField().LetsInsert("ada@example.com")
        ...
        .AndAlso().Should().HaveElement<FormsPage.Registration.Submit>()
            .That.AsButton().LetsClick();

    SharedContext.App.Should().HaveSection<FormsPage.Result>()
        .That.Should().HaveElement<FormsPage.Result.FullName>()
            .That.AsLabelText().Should().HaveValue("Ada Lovelace"); // a check that fails with a clear message
}
```

There are no waits in the tests: VAF waits for elements, for jQuery requests and, once it is told about one,
for a loader ([`LoadingTests`](VAF-Demo/Tests/Native/LoadingTests.cs)). After a click that loads a new page,
start a new chain from `HaveSection` — `AndAlso()` goes on with the section of the page that is gone.

Native tests are the quickest way to try VAF on a page. They are also the most expensive to keep: the same
chain appears in every test that fills the form.

## Level 2 — shared steps

[`SharedSteps`](VAF-Demo/SharedSteps) wrap a chain into one business action (`Lets…`) or check (`LetsCheck…`).
[`Tests/SharedSteps`](VAF-Demo/Tests/SharedSteps) has the same tests as level 1 for five pages, now in a few lines:

```csharp
[Test]
public void ValidRegistrationIsShownBack()
{
    FormsSteps.LetsRegister("Ada Lovelace", "ada@example.com", "analytical", "Croatia", plan: "Team");
    FormsSteps.LetsCheckTheResult("Ada Lovelace", "ada@example.com", "Croatia", plan: "Team");
}
```

Steps check through VAF's `Should()`, so a failed step reports what VAF found, not just "expected true".
Like the native tests, every step starts from `SharedContext.App`; a step such as `FormsSteps.LetsOpenTheForm`
fills it at the start of the test.

**One test, several cases.** `TablesStepsTests.FilterNarrowsTheTable` runs four times with NUnit's
`[TestCase]` — each case is one line of data.

### Maintenance

What changes when the page changes:

| The page changes… | Level 1 | Level 2 |
|---|---|---|
| A locator (`id="full-name"` becomes `id="name"`) | One page object class | One page object class |
| The flow (the form gets a new required field) | Every test that sends the form | One step (`LetsRegister`) |
| A text (the result title is reworded) | Every test that checks it | One step (`LetsCheckTheResult`) |

The page objects keep locators in one place at every level. Steps do the same for flows: a test says *what*
happens, a step says *how* it happens on the page.

## Level 3 — scenarios

[`Tests/Scenarios`](VAF-Demo/Tests/Scenarios): longer flows across several pages — from the practice overview to
the form, back through the breadcrumb, on to the table — written only with steps. A missing step is added to
`SharedSteps`, never written into the scenario.

The practice pages do not share any data, so these show the shape of a scenario, not a real end-to-end test,
where, say, an order placed on one page shows up on another.

## Tests against the site itself

[`Tests/Site`](VAF-Demo/Tests/Site): the same approach on pages that were not made for testing. The locators are
CSS selectors and link texts, the tests follow text that may change, and the contact test first declines the
cookie question, which otherwise covers the button it wants to click. The contact form is sent empty, so the
server rejects it and no email is sent; the site accepts at most 5 contact forms per address in 10 minutes, so
after a few runs in a row that test fails with *"… element is not present"* until the 10 minutes are over.

## When a test fails

[`TestBase`](VAF-Demo/Common/TestBase.cs) saves a screenshot after a failed test, and an HTML report of what
VAF did after every test, both in the test output folder (`bin/Debug/net10.0`). The browser is always closed.

## More

- [Guide](https://www.visionautomationframework.com/guide) — every control type, action and check
- [Practice pages](https://www.visionautomationframework.com/practice)
- [VAF on NuGet](https://www.nuget.org/packages/VisionAutomationFramework)
