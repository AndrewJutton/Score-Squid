using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using ScoreSquid.Web.Models;

namespace ScoreSquid.Web.Scheduler
{
    public class WebFixtureImporter : IWebFixtureParser, IFixtureHolder
    {
        private WebFixtureImporter()
        {
        }

        Collection<Fixture> IFixtureHolder.Fixtures { get; set; }

        public static IFixtureHolder Parse(XElement parsedHtml)
        {
            var p = new WebFixtureImporter();
            var holder = (IFixtureHolder)p;
            var fixtures = holder.Fixtures = new Collection<Fixture>();
            foreach (var tdElements in GetDescendentsByClass(parsedHtml, "td", "class", "details"))
            {
                var fixture = new Fixture();
                var date = DateTime.Parse(GetDescendentsByClass(tdElements.Parent, "td", "class", "date").First().Value);
                var homeTeam = GetDescendentsByClass(tdElements, "li", "class", "home").Elements().First().Value;
                var awayTeam = GetDescendentsByClass(tdElements, "li", "class", "away").Elements().First().Value;
                fixtures.Add(new Fixture {});
            }

            return p;
        }

        private static List<XElement> GetDescendentsByClass(XElement parsedHtml, string tag, string attributeName, string attributeValue)
        {
            return parsedHtml.Descendants(tag).Where(x => x.HasAttributes && x.Attributes().Any(v => v.Name == attributeName && v.Value == attributeValue)).ToList();
        }

        IFixtureHolder IWebFixtureParser.Parse(XElement parsedHtml)
        {
            return Parse(parsedHtml);
        }
    }

    public interface IWebFixtureParser
    {
        IFixtureHolder Parse(XElement parsedHtml);
    }

    public interface IFixtureHolder
    {
        Collection<Fixture> Fixtures { get; set; }
    }
}