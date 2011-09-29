using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz.Impl;
using Quartz;
using Common.Logging;
using System.Net;

namespace ScoreSquid.Web.Scheduler
{
    public class ChampionshipJob : IJob
    {
        private string championship = "http://www.football-data.co.uk/mmz4281/1112/E1.csv";

        private static ILog _log = LogManager.GetLogger(typeof(ChampionshipJob));

        public ChampionshipJob()
        {
        }

        public void Execute(JobExecutionContext context)
        {
            WebClient webClient = new WebClient();
            var fixtures = webClient.DownloadString(championship).Split(new char[] { '\n' });
            fixtures = fixtures.Take(fixtures.Count() - 1).ToArray();

            var resultImporter = new ResultImporter();
            resultImporter.Import(fixtures, "Championsip", "E2");
        }
    } 
}