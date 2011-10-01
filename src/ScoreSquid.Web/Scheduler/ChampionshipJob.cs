using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz.Impl;
using Quartz;
using Common.Logging;
using System.Net;
using ScoreSquid.Web.Services;

namespace ScoreSquid.Web.Scheduler
{
    public class ChampionshipJob : IJob
    {
        private static ILog _log = LogManager.GetLogger(typeof(ChampionshipJob));

        public ChampionshipJob()
        {
        }

        public void Execute(JobExecutionContext context)
        {
            var footballDataRepository = new FootballDataRepository();
            var results = footballDataRepository.LoadResults(footballDataRepository.ChampionshipResultsUri);

            if (results != null)
            {
                var resultImporter = new ResultImporter();
                resultImporter.Import(results, "Championsip", "E2");
            }
        }
    } 
}