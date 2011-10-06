using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace ScoreSquid.Web.Services
{
    public class FootballDataRepository
    {
        public string ChampionshipResultsUri
        {
            get { return "http://www.football-data.co.uk/mmz4281/1112/E1.csv"; }
        }

        public string LatestFixturesUri
        {
            get { return "http://www.football-data.co.uk/fixtures.csv"; }
        }

        public string[] LoadCsvFromUri(string uri)
        {
            WebClient webClient = new WebClient();
            var csvRows = webClient.DownloadString(uri).Split(new char[] { '\n' });
            return csvRows.Take(csvRows.Count() - 1).ToArray();
        }
    }
}
