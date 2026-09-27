# Vision Automation Framework — demo

Browser tests for [visionautomationframework.com](https://www.visionautomationframework.com), written with
[Vision Automation Framework](https://www.nuget.org/packages/VisionAutomationFramework) (VAF) **3.0 beta**.
They show how a VAF suite is built in practice, in three layers:

| Layer | File | What it holds |
|---|---|---|
| Elements | [`PageObjects/VafSite.cs`](VAF-Demo/PageObjects/VafSite.cs) | One page context for the whole site; the menu, page header, contact form … are sections with their elements nested inside |
| Steps | [`Steps/SiteSteps.cs`](VAF-Demo/Steps/SiteSteps.cs) | `Lets…` methods that wrap a fluent chain into one business action |
| Tests | [`Tests/SiteTests.cs`](VAF-Demo/Tests/SiteTests.cs) | Short NUnit tests that call the steps |

The tests cover navigation (menu, Quick start, Guide), reading and checking text, links, buttons, text
inputs, a text area, a select box and server-side form validation. A failed test leaves a screenshot and
an HTML report in the test output folder.

## Run

Requirements: the [.NET 10 SDK](https://dotnet.microsoft.com/download) and Google Chrome. Selenium
downloads the matching ChromeDriver on the first run.

```
dotnet test
```

or **Test → Run All Tests** in Visual Studio 2026.

The project is what Visual Studio's *NUnit Test Project* template creates (.NET 10, NUnit 4) plus the
VAF package. For .NET Framework, set `<TargetFramework>net472</TargetFramework>`.

## Settings

| Environment variable | Default | Meaning |
|---|---|---|
| `VAF_DEMO_BASE_URL` | `http://www.visionautomationframework.com` | The site under test |
| `VAF_ElementWaitTimeout` | 10 | Seconds VAF waits for an element (raise it for a slow first page load) |

The contact form tests only send invalid forms, which the server rejects, so no email is sent. The test
`ValidFormIsSent` sends a real message and therefore runs only against a local copy of the site
(`VAF_DEMO_BASE_URL=http://localhost:5199`); against any other address it is skipped.
