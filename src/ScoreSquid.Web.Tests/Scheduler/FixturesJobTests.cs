using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Machine.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoreSquid.Web.Scheduler;

namespace ScoreSquid.Web.Tests.Scheduler
{
    [TestClass]
    public class FixturesJobTests
    {
        private const string LeagueIndicator = "championship";
        private const string Url = "http://www.football.co.uk/fixtures/{0}/index.shtml";
        private string[] prefixes = new string[] { "g", "fb" };
        private XElement Html
        {
            get
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    "ScoreSquid.Web.Tests.Scheduler.output.html");
                string doc;
                using (var reader = new StreamReader(stream))
                {
                    doc = reader.ReadToEnd();
                }
                doc = doc.Replace("&", string.Empty);
                foreach (var prefix in prefixes)
                {
                    doc = doc.Replace(string.Format("<{0}:", prefix), "<");
                    doc = doc.Replace(string.Format("</{0}:", prefix), "</");
                }
                doc = doc.Replace("</body>", "</div></body>");
                File.WriteAllText(@"C:\output.html", doc);
                return
                    XElement.Parse(doc);
            }
        }

        [TestMethod]
        public void LoadFixturesFromHtml()
        {
            //var fixtureHolder = WebFixtureImporter.Parse(Html);
        }   
    }

}
