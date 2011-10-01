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

        public string[] LoadResults(string resultUri)
        {
            WebClient webClient = new WebClient();
            var fixtures = webClient.DownloadString(resultUri).Split(new char[] { '\n' });
            return fixtures.Take(fixtures.Count() - 1).ToArray();
        }
    }
}
