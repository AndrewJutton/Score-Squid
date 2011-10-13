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
            LoadResults(footballDataRepository);

            LoadFixtures(footballDataRepository);
        }

        private static void LoadFixtures(FootballDataRepository footballDataRepository)
        {
            var fixtures = footballDataRepository.LoadCsvFromUri(footballDataRepository.LatestFixturesUri);

            if (fixtures != null)
            {
                new FixtureImporter().Import(fixtures, "Championship", "E2");
            }
        }

        private static void LoadResults(FootballDataRepository footballDataRepository)
        {
            var results = footballDataRepository.LoadCsvFromUri(footballDataRepository.ChampionshipResultsUri);

            if (results != null)
            {
                var resultImporter = new ResultImporter();
                resultImporter.Import(results, "Championsip", "E2");
            }
        }
    }
}