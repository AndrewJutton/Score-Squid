using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreSquid.Web.ViewModels
{
    public class FixtureViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }
    }
}