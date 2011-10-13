﻿using System;
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

        private XElement Html
        {
            get
            {
                return
                    XElement.Load(
                        Assembly.GetExecutingAssembly().GetManifestResourceStream(
                            "ScoreSquid.Web.Tests.Scheduler.output.html"));
            }
        }

        [TestMethod]
        public void LoadFixturesFromHtml()
        {
            var fixtureHolder = WebFixtureImporter.Parse(Html);
        }   cm
    }

}