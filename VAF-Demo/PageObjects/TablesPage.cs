using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace VAF_Demo.PageObjects
{
    /// <summary>/practice/tables: 25 people, 10 per page, with a filter and sortable columns.</summary>
    public static class TablesPage
    {
        public class Filter : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("filter-form");

            public class Text : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("filter");
            }

            public class Apply : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("filter-button");
            }
        }

        /// <summary>"4 people · Page 1 of 1" above the table.</summary>
        public class Summary : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("summary");

            public class MatchCount : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("match-count");
            }
        }

        public class People : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("people");

            public class Body : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("people-body");
            }

            /// <summary>The name cell of every row; read as a list.</summary>
            public class Name : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("#people-body td.name");
            }

            public class FirstName : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("#people-body tr:first-child td.name");
            }

            public class FirstJoined : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("#people-body tr:first-child td.joined");
            }

            public class SortByJoined : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("sort-joined");
            }
        }
    }
}
