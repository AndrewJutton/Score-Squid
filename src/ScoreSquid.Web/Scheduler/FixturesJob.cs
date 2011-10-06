using System;
using Quartz;
using ScoreSquid.Web.Services;

namespace ScoreSquid.Web.Scheduler
{
    public class FixturesJob : IJob
    {
        public void Execute(JobExecutionContext context)
        {
            var footballDataRepository = new FootballDataRepository();
            var results = footballDataRepository.LoadCsvFromUri(footballDataRepository.LatestFixturesUri);

            if (results != null)
            {
                var resultImporter = new ResultImporter();
                resultImporter.Import(results, "Championsip", "E2");
            }
        }
    }
}